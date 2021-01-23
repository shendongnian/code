    class Caller
    {
        AutoResetEvent ev = new AutoResetEvent(false);
        public void A()
        {
            ev.Set();
            // do your stuff
            Console.Out.WriteLine("A---");
        }
        void B()
        {
            Console.Out.WriteLine("B---");
        }
        public void Start()
        {
            var checker = new BackgroundWorker();
            checker.DoWork += new DoWorkEventHandler(checker_DoWork);
            checker.RunWorkerAsync();
        }
        void checker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            while (!worker.CancellationPending)
            {
                bool called = ev.WaitOne(TimeSpan.FromSeconds(3));
                if (!called) B();
            }
        }
    }
