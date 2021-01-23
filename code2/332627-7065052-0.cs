        private readonly AutoResetEvent ProcessEvent = new AutoResetEvent(false);
        private readonly AutoResetEvent WakeEvent = new AutoResetEvent(false);
        public void Do()
        {
            Thread th1 = new Thread(ProcessSomething);
            th1.IsBackground = false;
            th1.Start();
            ProcessEvent.WaitOne();
            Console.WriteLine("Processing started...");
            Thread th2 = new Thread(() => WakeEvent.Set());
            th2.Start();
            
            th1.Join();
            Console.WriteLine("Joined");
        }
        private void ProcessSomething()
        {
            try
            {
                Console.WriteLine("Processing...");
                ProcessEvent.Set();
            }
            finally
            {
                WakeEvent.WaitOne();
                Console.WriteLine("Woken up...");
            }
        }
