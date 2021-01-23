    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;
    namespace ConsoleApplication1
    {
        class Program
        {
            private static void Method2(string[] strings)
            {
                int[] ints = new int[strings.Length];
                for (int i = 0; i < strings.Length; i++)
                {
                    ints[i] = Extract(strings[i]);
                }
                Array.Sort<int>(ints);
                foreach (int i in ints)
                {
                    Console.WriteLine(i);
                }
                Console.WriteLine("The smallest is {0}", ints[0]);
            }
            private static void Method1(string[] strings)
            {
                List<int> result = new List<int>();
                foreach (string s in strings)
                {
                    int value = Extract(s);
                    result.Add(value);
                }
                result.Sort();
                foreach (int i in result)
                {
                    Console.WriteLine(i);
                }
                Console.WriteLine("The smallest is {0}", result[0]);
            }
            static void Main(string[] args)
            {
                string[] strings  = new string[6];
                strings[0] = "test (9)";
                strings[1] = "test (4)";
                strings[2] = "test (7)";
                strings[3] = "test (1)";
                strings[4] = "test (2)";
                strings[5] = "test (8)";
                Console.WriteLine("\nMethod1 :");
                Method1(strings);
                Console.WriteLine("\nMethod2 :");
                Method2(strings);
                Console.ReadLine();
            }
            private static int Extract(string s)
            {
                // simply extract the digits
                return Convert.ToInt32(Regex.Match(s, @"\d+").Value);
            }
        }
    }
