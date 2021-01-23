    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Threading;
    using System.Diagnostics;
    
    namespace oops3
    {
    
       
        public class Demo
        {
          
            static void Main(string[] args)
            {
                Console.WriteLine("Enter the size of the array");
                int x = Convert.ToInt32(Console.ReadLine());
                int[] arr = new int[x];
                Console.WriteLine("Enter the elements of the array");
                for(int i=0;i<x;i++)
                {
                    arr[i] = Convert.ToInt32(Console.ReadLine());
                }
                int smallest = arr[0];
                int Largest = arr[0];
                for(int i=0;i<x;i++)
                {
                    if(smallest>arr[i])
                    {
                        smallest = arr[i];
                    }
                }
                for (int i = 0; i < x; i++)
                {
                    if (Largest< arr[i])
                    {
                        Largest = arr[i];
                    }
                }
                Console.WriteLine("The greater No in the array:" + Largest);
                Console.WriteLine("The smallest No in the array:" + smallest);
                Console.ReadLine();
    
            }
    
        }
    
    
                
    
           
           
    
               
    
               
    
    
            }
    
