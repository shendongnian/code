    using System;
    
    public class Example
    {
       public static void Main()
       {
          string line;
          do { 
             line = Console.ReadLine();
             if (line != null) 
                Console.WriteLine("Something.... " + line);
          } while (line != null);   
       }
    }
