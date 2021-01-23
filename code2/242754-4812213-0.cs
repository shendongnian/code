    using Timer = System.Threading.Timer;
    class Program
    {
        private static readonly Timer  _timer = 
            new Timer(o => Environment.Exit(0), null, 5000, Timeout.Infinite);
    
        static void Main(string[] args)
        {
            Console.ReadLine();
        }
    }
