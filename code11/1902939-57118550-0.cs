       using System;
        
        public class Example
        {
           public static void Main()
           {
              Random rnd = new Random();
              int min_value = 10;
              int max_value = 20;
        
              Console.WriteLine("\n20 random integers from 10 to 20:");
              for (int ctr = 1; ctr <= 20; ctr++) 
              {
                 Console.Write("{0,6}", rnd.Next(min_value, max_value));
                 if (ctr % 5 == 0) Console.WriteLine();
              }
           }
        }
