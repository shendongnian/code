    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace SecondLargest
    {
        class ArraySorting
        {
            public  static void Main()
            {
             int[] arr={5,0,2,1,0,44,0,9,1,0,23};
    
             int[] arr2 = new int[arr.Length];
             int arr2Index = 0;
             foreach (int item in arr)
             {
               if(item==0)
               {
                   arr2[arr2Index] = item;
                   arr2Index++;
               }
             }
             foreach (int item in arr)
             {
                if(item!=0)
                {
                    arr2[arr2Index] = item;
                    arr2Index++;
                }
             }
    
             foreach (int item in arr2)
             {
                 Console.Write(item+" ");
             }
    
                Console.Read();
    
            }
        }
    }
