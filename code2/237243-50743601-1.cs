    public static class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var baseAddress = new Uri(http://localhost:8161/MyService);
            var host = new ConsoleHost();
            host.Start(null);
            Console.WriteLine("The service is ready at {0}", baseAddress);
            Console.WriteLine("Press <Enter> to stop the service.");
            Console.ReadLine();
            host.Stop();
        }
    }
