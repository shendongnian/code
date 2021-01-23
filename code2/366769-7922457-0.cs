    using System;
    using System.Collections.Generic;
    class Program {
        static IEnumerable<string> GetPermutations(string value) {
            if (value.Length == 1) {
                yield return value;
            } else {
                for (int i = 0; i < value.Length; ++i) {
                    string a = value[i].ToString();
                    foreach (string b in GetPermutations(value.Remove(i, 1))) {
                        yield return a + b;
                    }
                }
            }
        }
        static void Main(string[] args) {
            string test = "INEEDTOGETAHAIRCUT";
            string chars = "OEGT";
            foreach (string to_find in GetPermutations(chars)) {
                int i = test.IndexOf(to_find);
                if (i != -1) {
                    Console.WriteLine("Found {0} at index {1}", to_find, i);
                }
            }
        }
    }
