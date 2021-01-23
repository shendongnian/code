    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApplication4
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<char> letters = new List<char>() { 'a', 'b', 'c', 'd' };
                List<string> words = new List<string>();
                Action<IEnumerable<char>, string, List<string>> recursiveLetter = null;
                recursiveLetter = (availLetters, word, newWords) =>
                {
                    if (word.Length < availLetters.Count())
                    {
                        availLetters.ToList()
                                    .ForEach(currentletter => 
                                               recursiveLetter(availLetters, 
                                                               word + currentletter, 
                                                               newWords));
                    }
                    else
                    {
                        newWords.Add(word);
                    }
                };
                recursiveLetter(letters, string.Empty, words); // ALL THE MAGIC GO!
                words.ForEach(word => Console.WriteLine(word));
                Console.ReadKey();
            }
        }
    }
