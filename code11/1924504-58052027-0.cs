            HashSet<char> characters = new HashSet<char>();
            foreach (char c in text)
            {
                if (Char.IsLetter(c))
                {
                    // This will add the character ONLY if it is not there
                    characters.Add(c);
                }
            }
Full console app. If you want to try it create a new console app and replace all the Programs.cs by this:
using System;
using System.Collections.Generic;
using System.Linq;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "evEn There";
            // HashSet is like a list, but without duplicates
            HashSet<char> characters = new HashSet<char>();
            // First make all characters lower case
            text = text.ToLower();
            foreach (char c in text)
            {
                if (Char.IsLetter(c))
                {
                    // This will add the character ONLY if it is not there, if not it returns false
                    bool couldBeInserted = characters.Add(c);
                }
            }
            string allCharacters = new String(characters.ToArray());
                
            //This will print: "evnthr"
            Console.WriteLine(allCharacters);
        }
    }
}
