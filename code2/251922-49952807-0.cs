    using System;
 
    public class Program
    {
       public static void Main()
       {
          Console.WriteLine("This is a number pyramid....");
          var rows = 5;
          for(int i = 1; i <= rows; i++)
          {
             for(int lsc = (-rows); lsc <= -2; lsc ++)
             {
                if(lsc < (-1)*i)
                {
                   //write left sided blank spaces
                   Console.Write(" ");
                }
                else
                {
                   //write left sided numbers
                   Console.Write(-1*(lsc));
                }
             }
             for(int rsc = 1; rsc <= rows; rsc++)
             {
                //write right sided blank spaces
                Console.Write(" ");
             }
             else
             {  
                //Write sided numbers
                Console.Write(rsc);
             }
           } 
          Console.WriteLine();
        }
      }
    } 
