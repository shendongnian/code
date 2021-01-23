    using System;
    
    class Test
    {
        static void Main(string[] args)
        {
            // Argument validation left as an exercise for the reader
            string word = args[0];
            Console.WriteLine("Word {0} has {1} possibilities",
                              word, Math.Pow(2, word.Length - 1));
        }
    }
