    using System;
    class Program {
        static void Main(string[] args) {
            string full = "Bacliff New Texas United States";
            // split the string in words
            string[] words = full.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int size = 1; size < words.Length; ++size) {
                // get substrings of 'size' words
                for (int start = 0; start <= words.Length - size; ++start) {
                    string[] before = new string[start];
                    string[] destination = new string[size];
                    string[] after = new string[words.Length - (size + start)];
                    Array.Copy(words, 0, before, 0, before.Length);
                    Array.Copy(words, start, destination, 0, destination.Length);
                    Array.Copy(words, start + destination.Length, after, 0, after.Length);
                    Console.WriteLine("{0} % {1} % {2}",
                        string.Join(" ", before),
                        string.Join(" ", destination),
                        string.Join(" ", after));
                }
            }
        }
    }
