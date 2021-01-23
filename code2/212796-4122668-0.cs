    static void Thread1()
    {
        System.Threading.Thread.Sleep(5000);
        Console.WriteLine("hi");
    
     }
    
    static void Main(string[] args)
    {
        System.Threading.Thread T = new System.Threading.Thread(Thread1);
        T.Start();
        while (T.IsAlive)
        {
              System.Threading.Thread.Sleep(1000);
              Console.WriteLine("Waiting");
    
        }
        Console.WriteLine("Finished");
                
    }
