    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApp3
    {
        class Program
        {
            static readonly char[] digits = "0123456789".ToCharArray();
            static void Main(string[] args)
            {
                string[] arr = { "12", "34-2-2", "xyz", "33", "56-3-4", "45-4" };
                var pair = ProcessInput(arr);
                Console.WriteLine(String.Join(", ", pair.Item1));
                Console.WriteLine(String.Join(", ", pair.Item2));
                var done = Console.ReadLine();
            }
            static Tuple<string[], string[]> ProcessInput(string[] input)
            {
                var l1 = new List<string>();
                var l2 = new List<string>();   
                foreach(var item in input)
                {
                    if (ContainsOnlyIntegers(item))
                    {
                        l1.Add(item);
                        continue; // move on.
                    }
                    var parts = item.Split('-');
                    if (parts.Length == 3 && parts.All(part => ContainsOnlyIntegers(part)))
                    {
                        //must have 3 parts, separated by hypens and they are all numbers.                    
                        l2.Add(item);
                    }
                }
                return Tuple.Create(l1.ToArray(), l2.ToArray());
            }
            static bool ContainsOnlyIntegers(string input)
            {
                return input.ToCharArray().All(r => digits.Contains(r));
            }
        }
    }
