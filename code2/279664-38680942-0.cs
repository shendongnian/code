    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace LinearSearch
    {
    class Program
    {
        
        static void Main(string[] args)
        {
            int var1 = 50;
            int[] arr;
            arr = new int[10]{10,20,30,40,50,60,70,80,90,100};
            int retval = linearsearch(arr,var1);
             if (retval >= 1)
             {
               Console.WriteLine(retval);
               Console.Read();
             }
             else
             { Console.WriteLine("Not found"); Console.Read(); }
        }
        static int linearsearch(int[] arr, int var1)
        {
            int pos = 0;
            int posfound = 0;
            foreach (var item in arr)
            {
                pos = pos + 1;
                if (item == var1)
                {
                    posfound = pos;
                    if (posfound >= 1)
                        break;
                }     
            }  
            return posfound;
        }
    }
    }
