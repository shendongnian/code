    class Program
    {
        static int count;
        static Thread thrd;
        public static void MyThread(string name) { 
            count = 0; 
            thrd = new Thread(new ThreadStart(run)); // here m getting error
            thrd.Name = name; 
            thrd.Start(); 
        } 
      // Entry point of thread. 
      static void  run() { 
        Console.WriteLine(thrd.Name + " starting.");
        do
        {
            Thread.Sleep(500);
            Console.WriteLine("In " + thrd.Name +
                              ", count is " + count);
            count++;
        } while (count == 5);
      }
      static void Main(string[] args)
      {
      }
    }
