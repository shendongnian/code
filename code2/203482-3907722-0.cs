    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting");
            Task.Factory.StartNew(
                () =>
                    {
                        Console.WriteLine("Background 1");
                      Thread.Sleep(1000);
                      Console.WriteLine("Background 2");
                    });
            Console.WriteLine("Blocking");
            Console.ReadLine();
        }
    }
