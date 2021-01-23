        BackgroundWorker worker = new BackgroundWorker() { WorkerSupportsCancellation = true };
        public void ProcessFile(StreamReader Reader)
        {
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerAsync(Reader);
        }
        public void CancelProcessFile()
        {
            worker.CancelAsync();
        }
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            StreamReader Reader = e.Argument as StreamReader;
            if (Reader != null)
            {
                while (Reader.Peek() != -1 && !((BackgroundWorker)sender).CancellationPending)
                {
                    var Line = Reader.ReadLine();
                    //TODO: Process Line
                }
            }
        }
