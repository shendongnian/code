    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApp22
    {
        public class Pair
        {
            public int Value { get; set; }
            public int Sum { get; set; }
    
            public Pair(int val, int sum)
            {
                Value = val;
                Sum = sum;
            }
            public void AddToSum(int x)
            {
                Sum += x;
            }
            public override string ToString()
            {
                return $"Value: {Value}, Sum: {Sum}";
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                int[] array = new[] { 12, 12, 12, 12, 12, 17, 17, 17, 17, 12, 12, 12, 12, 12, 17, 17, 17, 17, 17, 17, 17, 12, 12, 12, 12, 12 };
                var list = new List<Pair>();
    
                var pair = new Pair(array[0], array[0]);
                for (int i = 1; i < array.Length; i++)
                {
                    int current = array[i];
                    int previous = array[i - 1];
                    if (current != previous)
                    {
                        list.Add(pair);
                        pair = new Pair(current, current);
                    }
                    else
                    {
                        pair.AddToSum(current);
                    }
                }
    
                print(list);
    
                Console.WriteLine("Done!");
                Console.ReadKey();
            }
    
            static void print(List<Pair> list)
            {
                for (int i = 1; i < list.Count; i++)
                {
                    Console.WriteLine(list[i].ToString());
                }
            }
        }
    }
