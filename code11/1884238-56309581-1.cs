    using System;
    using System.Linq;
    public class Test
    {
	   public static void Main()
	   {
		 string[] unsorted = { "1","2", "100","12303479849857341718340192371",
                           "3084193741082937","3084193741082938","111","200" };
          unsorted.OrderBy(s => s.Length).ThenBy(s => s);
          Console.WriteLine("Sorted numbers are:");
          foreach (var x in unsorted) {
        	   Console.WriteLine(x);
          }
	   }
    }
