    static void Main(string[] args)
    {
        Task task1 = new Task((obj) => PrintMsg(obj), "Hello Task");
        task1.Start();
        // or Console.ReadLine();
        task1.Wait();
    }
    
    static void PrintMsg(object msg)
    {
        Console.WriteLine(msg);
    }
