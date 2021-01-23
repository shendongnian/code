    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace TestDataStructures
    {
        class Program
        {
            static void Main(string[] args)
            {
                SortedList<int, string> dict = new SortedList<int, string>();
                for (int i = 42; i < 100; i++) {
                    dict.Add(i, i.ToString());
                }
                for (int i = 41; i > 0; i--) {
                    dict.Add(i, i.ToString());
                }
    
                Console.Out.WriteLine("Smallest value is " + dict.Values[0]);
                Console.ReadKey();
            }
        }
    }
