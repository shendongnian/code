    using System.Collections.Generic;
    using System.Linq;
    
    namespace caComb
    {
        class Program
        {
            private static List<List<string>> allCombinations = new List<List<string>>();
            static void Main(string[] args)
            {
                string[] words = new string[] { "one", "two", "three", "four", "five" };
                List<string> temp = new List<string>();
                GetCombinations(words, temp);
                // Here you can read all combinations from
                // allCombinations. Do whatever you want.
            }
    
            private static void GetCombinations(string[] words, List<string> temp)
            {
                if (temp.Count == words.Length)
                {
                    List<string> clone = temp.ToList();
                    if (clone.Distinct().Count() == clone.Count)
                    {
                        allCombinations.Add(clone);
                    }
                    return;
                }
    
                for (int i = 0; i < words.Length; i++)
                {
                    temp.Add(words[i]);
                    GetCombinations(words, temp);
                    temp.RemoveAt(temp.Count - 1);
                }
    
            }
        }
    }
