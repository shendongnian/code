    // statements_foreach_arrays.cs
    // Using foreach with arrays
    using System;
    class MainClass 
    {
       public static void Main() 
       {
          int odd = 0, even = 0;
          int[] arr = new int [] {0,1,2,5,7,8,11};
    
          foreach (int i in arr) 
          {
             if (i%2 == 0)  
                even++;      
             else 
                odd++;         
          }
    
          Console.WriteLine("Found {0} Odd Numbers, and {1} Even Numbers.",
                            odd, even) ;
       }
    }
