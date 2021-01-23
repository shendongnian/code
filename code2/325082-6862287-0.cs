    public static void Main()
    {
        ThreadPool.QueueUserWorkItem(
            (state) =>
            {
                throw new InvalidOperationException();
            }, null);
    
        while (true)
        {
           Thread.Sleep(1000);
           Console.WriteLine(DateTime.Now.ToString());
        }
    }
