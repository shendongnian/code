    public class ConcurrentQueue
    {
        private Dictionary<byte, PoolFiber> Actionsfiber;
        public ConcurrentQueue()
        {
            Actionsfiber = new Dictionary<byte, PoolFiber>()
            {
                { 1, new PoolFiber() },
                { 2, new PoolFiber() },
                { 3, new PoolFiber() },
            };
            foreach (var fiber in Actionsfiber.Values)
            {
                fiber.Start();
            }
        }
            
        public void ExecuteAction(Action Action , byte Code)
        {
            if (Actionsfiber.ContainsKey(Code))
                Actionsfiber[Code].Enqueue(() => { Action.Invoke(); });
            else
                Console.WriteLine($"invalid byte code");
        }
    }
    public static void SomeAction1()
    {
        Console.WriteLine($"{DateTime.Now} Action 1 is working");
        for (long i = 0; i < 2400000000; i++)
        {
        }
        Console.WriteLine($"{DateTime.Now} Action 1 stopped");
    }
                
    public static void SomeAction2()
    {
        Console.WriteLine($"{DateTime.Now} Action 2 is working");
        for (long i = 0; i < 5000000000; i++)
        {
        }
        Console.WriteLine($"{DateTime.Now} Action 2 stopped");
    }
                
    public static void SomeAction3()
    {
        Console.WriteLine($"{DateTime.Now} Action 3 is working");
        for (long i = 0; i < 5000000000; i++)
        {
        }
        Console.WriteLine($"{DateTime.Now} Action 3 stopped");
    }
    
    public static void Main(string[] args)
    {
        ConcurrentQueue concurrentQueue = new ConcurrentQueue();
        concurrentQueue.ExecuteAction(SomeAction1, 1);
        concurrentQueue.ExecuteAction(SomeAction2, 2);
        concurrentQueue.ExecuteAction(SomeAction3, 3);
        concurrentQueue.ExecuteAction(SomeAction1, 1);
        concurrentQueue.ExecuteAction(SomeAction2, 2);
        concurrentQueue.ExecuteAction(SomeAction3, 3);
        Console.WriteLine($"press any key to exit the program");
        Console.ReadKey();
    }
