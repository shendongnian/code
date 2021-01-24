    class Program
    {
        public static event EventHandlery<MyArgs> MyEvent;
        static void Main(string[] args)
        {
            ProgramTest prog = new ProgramTest();
    
            prog.AddMethod();
    
            // raise the event and invoke the registered handlers
            MyEvent?.Invoke(new MyArgs());
        }
    }
    
    class ProgramTest
    {
        private delegate void execute(object sender, MyArgs e);
    
        public ProgramTest()
        {
            execute = Print;
        }
    
        public void AddMethod()
        {
            Program.MyEvent += execute;  // regsiter the execute-delegate to the event
            // or directly: Program.MyEvent += Print;
        }
    
        public void Print(object sender, MyArgs e)
        {
            Console.WriteLine("test");
            Console.ReadLine();
        }
    }
