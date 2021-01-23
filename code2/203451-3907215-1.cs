      class ThreadingWithBg
    {
        BackgroundWorker bg = null;
        public ThreadingWithBg()
        {
            bg = new BackgroundWorker();
            bg.DoWork += new DoWorkEventHandler(bg_DoWork);
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);
         
        }
        void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
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
            
        }
    }
