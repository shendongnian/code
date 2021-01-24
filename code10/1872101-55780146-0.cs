using System;
public class Example
{
   public static void Main()
   {
      string line;
      do { 
         line = Console.ReadLine();
         if (line != null) 
            Console.WriteLine("Now I have detected the end of stream.... " + line);
      } while (line != null);   
   }
}
