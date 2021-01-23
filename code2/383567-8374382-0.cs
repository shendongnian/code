        object oLock = new object();
        Queue<string> requests = new Queue<string>();
        Queue<string> responses = new Queue<string>();
        Thread mThread;
        AutoResetEvent mEvent = new AutoResetEvent(false);
        public Form1()
        {
            InitializeComponent();
            mThread = new Thread(ProcessingEngine);
            mThread.IsBackground = true;
            mThread.Start();
        }
        private void ProcessingEngine()
        {
            string result;
            string request = null;
            while (true)
            {
                try
                {
                    mEvent.WaitOne();
                    lock (oLock)
                    {
                        request = requests.Dequeue();
                    }
                    var wc = new WebClient();
                    result = wc.DownloadString(request);
                    lock (oLock)
                    {
                        responses.Enqueue(result);
                    }
                }
                catch (Exception ex)
                {
                    lock (oLock)
                    {
                        responses.Enqueue(ex.ToString());
                    }
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lock (oLock)
            {
                //Stick in a new request
                requests.Enqueue("http://yahoo.com");
                
                //Allow thread to start work
                mEvent.Set();
                //Check if a response has arrived
                if (responses.Any())
                {
                    var result = responses.Dequeue();
                    listBox1.Items.Add(result.Substring(1,200));
                }
            }
        }
    }
