      class ThreadingWithBg
    {
        BackgroundWorker bg = null;
        //  it's just a signaling mechanism to Paly/Pause Main UI thread.
        ManualResetEvent mReset = new ManualResetEvent(false);
        public ThreadingWithBg()
        {
            bg = new BackgroundWorker();
            bg.DoWork += new DoWorkEventHandler(bg_DoWork);
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);
         
        }
        void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // don't forget to wake up UI thread.
            mReset.Set();
        }
        void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 100000; i++)
            {
                Console.WriteLine(i.ToString());
            }
        }
        public void DoLongWork()
        {
            bg.RunWorkerAsync();
            mReset.WaitOne();// this line will block main UI thread.
        }
    }
