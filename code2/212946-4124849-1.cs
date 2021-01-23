    class Worker
    {
        public Exception TheadException { get; private set; }
        public void Start()
        {
            try
            {
                // Do your thing
            }
            catch (Exception ex)
            {
                TheadException = ex;
            }
        }
    }
....
        static void Main(string[] args)
        {
            Worker workerObject = new Worker();
            var workerThread = new System.Threading.Thread(workerObject.Start);
            workerThread.Start();
            workerThread.Join();
            if (workerObject.TheadException != null)
                Console.WriteLine("Thread failed with exception {0}", workerObject.TheadException);
        }
