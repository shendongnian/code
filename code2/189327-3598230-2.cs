    public class Program
    {
        public EventHandler OnStart;
        public static EventHandler LogOnStart = (s, e) => Console.WriteLine("starts");
        public class MyCSharpProgram
        {
            public string Name { get; set; }
            // just a field to an EventHandler
            public EventHandler OnStart = (s, e) => { /* do nothing */ }; // needs to be initialized to use "+=", "-=" or suppress null-checks
            public void Start()
            {
                // always check if non-null
                if (OnStart != null)
                    OnStart(this, EventArgs.Empty);
            }
        }
        static void Main(string[] args)
        {
            MyCSharpProgram cs = new MyCSharpProgram { Name = "C# test" };
            cs.OnStart += LogOnStart;  //can compile
            RegisterLogger(cs.OnStart);   // should work now
            cs.Start();   // it prints "start" (of course it will :D)
            Program p = new Program();
            RegisterLogger(p.OnStart);   //can compile
            p.OnStart(p, EventArgs.Empty); //can compile, but NullReference at runtime
            Console.Read();
        }
        static void RegisterLogger(EventHandler ev)
        {
            // Program.OnStart not initialized so ev is null
            if (ev != null) //null-check just in case
                ev += LogOnStart;
        }
    }
