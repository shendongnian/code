    class Program
    {
      private static string input;
      
      public static void Main()
      {
    	Thread t = new Thread(new ThreadStart(work));
    	input = Console.ReadLine();
    	
      }
      
      private static void work()
      {
         while (input == null)
    	 {
    	   //do stuff....	   
    	 }
      }
    }
