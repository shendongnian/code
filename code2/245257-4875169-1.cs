    using System;
    class Program {
        static void Main(string[] args) {
            string full = "Bacliff New Texas United States";
            // split the string in words
            string[] words = full.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            // get substrings 'size' words long
            for (int size = 1; size <= words.Length; ++size) {
                string[] destination = new string[size];
                for (int start = 0; start <= words.Length - size; ++start) {
                    Array.Copy(words, start, destination, 0, size);
                    Console.WriteLine(string.Join(" ", destination));
                }
            }
        }
    }
