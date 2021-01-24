    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    namespace Rextester
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                //Your code goes here
                Console.WriteLine("Hello, world!");
                string file = "Berzas,sula;;sula;;klevu saldial lapasula a aila, ar suart zemes vaikai du       ";
                int n = 0;
                while (Math.Pow(n, 2) != file.Length)  
                {
                    n++;
                }
    
                string[,] array = new string[n, n];
    
                var list = Enumerable
                .Range(0, file.Length / n)
                .Select(i => file.Substring(i * n, n))
                .ToList();
                         
                var res = string.Join(Environment.NewLine, list);
                for (int i = 0; i < n; i++)
                {
                    char[] row = list[i].ToCharArray();
                    for (int j = 0; j < n; j++)
                    {
                        array[i, j] = row[j].ToString();
                    }
                }
                
                int rowLength = array.GetLength(0);
                int colLength = array.GetLength(1);
                for (int i = 0; i < rowLength; i++)
                {
                    for (int j = 0; j < colLength; j++)
                    {
                        Console.Write(string.Format("{0}", array[i, j]));
                    }
                    Console.Write(Environment.NewLine);
                }
                
            }
        }
    }
