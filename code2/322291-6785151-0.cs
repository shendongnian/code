    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ListCluster
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<int> input = new List<int>() { 3, 27, 53, 79, 113, 129, 134, 140, 141, 142, 145, 174, 191, 214, 284, 284 };
                input.Sort();
    
                List<List<int>> result = new List<List<int>>();
    
                int currentList = 0;
                int? previousValue = null;
    
                result.Add(new List<int>());
    
                foreach (int i in input)
                {
                    if (!previousValue.HasValue || i - previousValue < 5)
                    {
                        result[currentList].Add(i);
                    }
                    else
                    {
                        currentList++;
                        result.Add(new List<int>());
                        result[currentList].Add(i);
                    }
    
                    previousValue = i;
    
                }
    
                foreach (List<int> list in result)
                {
                    foreach (int r in list)
                    {
                        Console.Write(r);
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
