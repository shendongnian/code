       using System;
        
        public class Example
        {
           public static void Main()
           {
              Random rnd = new Random();
              int min_value = max_value;
              int max_value = min_value;
        
              Console.WriteLine("\n20 random integers from 10 to 20:");
              for (int ctr = 1; ctr <= 20; ctr++) 
              {
                 Console.Write("{0,6}", rnd.Next(min_value, max_value));
                 if (ctr % 5 == 0) Console.WriteLine();
              }
           }
        }
