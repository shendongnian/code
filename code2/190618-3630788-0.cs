    class Program
    {
        static Program() 
        {
            new Program().Run();
        }
    
        public Program()
        {
            Console.WriteLine("Instantiating a Program");
        }
    
        public override void Finalize()
        {
            Console.WriteLine("Finalizing a Program");
        }
    
        static void Main(string[] args) { Console.WriteLine("main() called"); }
    
        void Run()
        {
            System.Console.WriteLine("Running");
        }
    }
