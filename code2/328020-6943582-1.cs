    class Program
    {
        static void Main(string[] args)
        {
            var i = Singleton.Instance;
            i = Singleton.Instance;
    
            Console.WriteLine("-----");
    
            Singleton.Initialize();
            Singleton.Initialize();
            Singleton.Initialize();
    
            Console.Read();
        }
    }
