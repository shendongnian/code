    class Program
    {
        public static volatile bool done = false;
        static void Main(string[] args)
        {
            WorkerClass worker = new WorkerClass();
            worker.Callback = new WorkerCallbackDelegate(WorkerCallback);
            System.Threading.Thread thread = new System.Threading.Thread(worker.DoWork);
            thread.Start();
            while (!done)
            {
                System.Threading.Thread.Sleep(100);
            }
            Console.WriteLine("Done");
            Console.ReadLine();
        }
        public static void WorkerCallback(object dataArg)
        {
            // handle dataArg
            done = true;
        }
    }
    public delegate void WorkerCallbackDelegate(object dataArg);
    class WorkerClass
    {
        public WorkerCallbackDelegate Callback { get; set; }
        public void DoWork()
        {
            // do your work and load up an object with your data
            object data = new object();
            Callback(data);
        }
    }
