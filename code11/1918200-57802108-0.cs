    using System;
    using System.Linq;
    namespace Demo
    {
        class Program
        {
            public static void Main(string[] args)
            {
                string text = "Hello World";
                Console.WriteLine(Reverse(text));  // Prints "olleH dlroW"
            }
            public static string Reverse(string text)
            {
                var words = text.Split(' ');
                return words.Length == 1 
                    ? new string(words[0].Reverse().ToArray()) // Not recursive; using Enumerable.Reverse()
                    : string.Join(" ", words.Select(Reverse)); // <- Here's the recursive call.
            }
        }
    }
