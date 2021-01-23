    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace Array_Small_and_lagest
    {
        class Program
        {
            static void Main(string[] args)
            {
                int[] array = new int[10];
                Console.WriteLine("enter the array elements to b sorted");
                for (int i = 0; i < 10; i++)
                {
                    array[i] = Convert.ToInt32(Console.ReadLine());
                }
                int smallest = array[0];
                foreach (int i in array)
    
                {
                    if (i < smallest)
                    {
                        smallest = i;
    
                    }
                }
                int largest = array[9];
                foreach (int i in array)
                {
    
                    if (i > largest)
                    {
                        largest = i;
    
                    }
                }
                Console.WriteLine("the smallest no is {0}", smallest);
                Console.WriteLine("the largest no is {0}", largest);
                Console.Read();
    
    
            }
        }
    }
