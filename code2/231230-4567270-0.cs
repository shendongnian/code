    using System;
    using System.Collections.Generic;
    
    using System.Linq;
    
    namespace Fibonacci
    {
        class MainClass
        {
            public static void Main (string[] args)
            {
               
                Console.WriteLine("Sans list. Lazy load stuff:");
                int i = 0;
                foreach(int n in Fibonacci().Take(10))
                {
                    ++i;
                    Console.WriteLine("Loading {0} {1}", i, n);             
                }
                
                
                Console.WriteLine("\nPick the 20th fibonacci:");
                Console.WriteLine("\n20th fibonacci: {0}", 
                             Fibonacci().Skip(20 - 1).Take(1).Single());
                
                
                Console.WriteLine("\nEagerly load everything in list:");
                i = 0;
                foreach(int n in Fibonacci().Take(10).ToList())
                {
                    ++i;
                    Console.Write("\nEager loading {0} {1}", i, n);
                }
                        
            }
            
    
                            
            static IEnumerable<int> Fibonacci()
            {
             int a = 0,  b = 1;
                
             Console.Write("Lazy");
             yield return a;
                
             for(;;)
             {
              int n = a;
              a += b;
              b = n;
              Console.Write("Lazy");
              yield return a;
             }
                     
                
            }
    
    
        }
        
    
    }
