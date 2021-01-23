    class CalledClass
    {
        public static void PokeCaller()
        {
            Program._this.Error = "Error!!!";
        }
    }
    
    class Program
    {
        public string Error = null;
        [ThreadStatic] public static Program _this;
        public void Run()
        {
            _this = this;
            CalledClass.PokeCaller();
            Console.WriteLine(Error);
            Console.ReadKey();
        }
    
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }
    }
