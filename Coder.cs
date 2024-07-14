using System.Reflection;
using System.Text.RegularExpressions;

/*
 * 
 * File: Coder.cs
 * Programmer: miguesgo
 * Date: 13/07/2024
 * 
 */

namespace MorseCoder
{
    internal class Coder
    {
        private string phrase = string.Empty;
        private string pattern = "(^[A-Z0-9]*$)";
        private string method = "Symbol";
        private string phraseInMorse = string.Empty;

        public void startCoder()
        {
            Console.WriteLine("Please insert the phrase [Az-09] you want to convert into morse code: ");
            phrase = Console.ReadLine()!;
            phrase = phrase.ToUpper();

            if (!Regex.IsMatch(phrase, pattern))
            {
                Console.WriteLine($"{phrase} is an invalid input, please try again");
                return;
            }

            foreach (char letter in phrase!)
            {
                MethodInfo methodInfo = typeof(Alphabet).GetMethod(method + letter)!;
                phraseInMorse = (string)methodInfo.Invoke(new Alphabet { }, null)!;
                Console.Write(phraseInMorse);
            }

            Thread.Sleep(5000);
        }
    }
}
