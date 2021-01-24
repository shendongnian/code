    class Program
    {
        public static event Action MyEvent;
        static void Main(string[] args)
        {
            ProgramTest prog = new ProgramTest();
    
            prog.AddMethod();
    
            // raise the event and invoke the registered handlers
            MyEvent?.Invoke();
        }
    }
    
    class ProgramTest
    {
        private Action handler;
    
        public ProgramTest()
        {
            handler = Print;
        }
    
        public void AddMethod()
        {
            Program.MyEvent += handler;  // regsiter the execute-delegate to the event
            // or directly: Program.MyEvent += Print;
        }
    
        public void Print()
        {
            Console.WriteLine("test");
            Console.ReadLine();
        }
    }
