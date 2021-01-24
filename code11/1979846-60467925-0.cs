c#
public class Program
    {      
      public static void Main(string[] args)
        {
          char x = 'X';
          int i = 0;
		  
		  // Prints X fine
		  Console.WriteLine(x);
		  
		  // Prints System.Int32
		  Console.WriteLine((true ? x : 0).GetType());
		  
		  // Both print 88 - the int value of 'X'
          Console.WriteLine(true ? x : 0);
          Console.WriteLine(false ? i : x); 
        }
    }
