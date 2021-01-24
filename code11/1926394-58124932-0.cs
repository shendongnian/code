    class Program
    {
        Task task1 = null;
        Task task2 = null;
        static void Main(string[] args)
        {
            Program newProgram = new Program();
            newProgram.runtasks();
            Console.ReadKey();
        }
        public  void runTheSecondOne(object source, EventArgs e)
        {
            Console.WriteLine("::runTheSecondOne::");
            task2 = Task.Run(() => Method2());
            Task.WaitAll(task1, task2);
        }
        public void Method1()
        {
            Console.WriteLine("::Method1::");
        }
        public void Method2()
        {
            Console.WriteLine("::Method2::");
        }
        public void runtasks()
        {
            task1 = Task.Run(() => Method1());
            //Can I insert a delay here to make Task1 5ms slower
            Timer actionDelayer= new Timer();
            actionDelayer.AutoReset = false;
            actionDelayer.Interval = 5;
            actionDelayer.Elapsed += new ElapsedEventHandler(runTheSecondOne);
            actionDelayer.Enabled = true;
        }
    }
