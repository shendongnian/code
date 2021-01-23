    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace SortInSubSet
    {
        class Program
        {
    
            static int N, K;
            static Dictionary<int, int> dicElements = new Dictionary<int, int>();
            static void Main(string[] args)
            {
    
                while (!ReadNK())
                {
                    Console.WriteLine("***************** PLEASE RETRY*********************");
                }
    
                var sortedDict = from entry in dicElements orderby entry.Key/3 , entry.Value ascending select entry.Value;
    
                foreach (int ele in sortedDict)
                {
                    Console.Write(ele.ToString() + "  ");
                }
    
                Console.ReadKey();
            }
    
            static bool ReadNK()
            {
                dicElements = new Dictionary<int, int>();
                Console.WriteLine("Please entere the No. of element 'N' ( Between 2 and 9999) and Subset Size 'K' Separated by space.");
    
                string[] NK = Console.ReadLine().Split();
    
                if (NK.Length != 2)
                {
                    Console.WriteLine("Please enter N and K values correctly.");
                    return false;
                }
    
                if (int.TryParse(NK[0], out N))
                {
                    if (N < 2 || N > 9999)
                    {
                        Console.WriteLine("Value of 'N' Should be Between 2 and 9999.");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid number: Value of 'N' Should be greater than 1 and lessthan 10000.");
                    return false;
                }
    
                if (int.TryParse(NK[1], out K))
                {
                    Console.WriteLine("Enter all elements Separated by space.");
                    string[] kElements = Console.ReadLine().Split();
    
                    for (int i = 0; i < kElements.Length; i++)
                    {
                        int ele;
    
                        if (int.TryParse(kElements[i], out ele))
                        {
                            if (ele < -99999 || ele > 99999)
                            {
                                Console.WriteLine("Invalid Range( " + kElements[i] + "): Element value should be Between -99999 and 99999.");
                                return false;
                            }
    
                            dicElements.Add(i, ele);
                        }
                        else
                        {
                            Console.WriteLine("Invalid number( " + kElements[i] + "): Element value should be Between -99999 and 99999.");
                            return false;
                        }
    
                    }
    
                }
                else
                {
                    Console.WriteLine(" Invalid number ,Value of 'K'.");
                    return false;
                }
    
    
                return true;
            }
        }
    }
