    public class Program 
    {     
      private /*volatile*/ bool stop = false;     
    
      public static void Main(string[] args)
      {
        new Program().Test();
      }
    
      private void Test()
      {
        Thread thread = new Thread(Run);
        thread.Start();
        Thread.Sleep(1000);         
        stop = true;
        thread.Join();
        Console.WriteLine("exit");
        Console.ReadLine();
      }
    
      private void Run()
      {
        int i = 0;
        while (!stop)     
        {
          i++;
        }
      }
    }
