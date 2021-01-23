    using System.IO;
    
    class Program
    {
        static void Main()
        {
    	      using (StreamWriter writer = new StreamWriter("important.txt"))
    	      {
    	            writer.Write("Word ");
    	            writer.WriteLine("word 2");
    	            writer.WriteLine("Line");
    	      }
        }
    }
