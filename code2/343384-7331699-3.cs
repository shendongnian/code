        BackgroundWorker worker = new BackgroundWorker() { WorkerSupportsCancellation = true };
        //Take a stream reader (representation of a text file) and process it asyncronously
        public void ProcessFile(StreamReader Reader)
        {
            worker.DoWork += worker_DoWork;
            worker.RunWorkerAsync(Reader);
        }
        public void CancelProcessFile()
        {
            worker.CancelAsync();
        }
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            //Get the reader passed as an argument
            StreamReader Reader = e.Argument as StreamReader;
            if (Reader != null)
            {
                //while not at the end of the file and cancellation not pending
                while (Reader.Peek() != -1 && !((BackgroundWorker)sender).CancellationPending)
                {
                    //Read the next line
                    var Line = Reader.ReadLine();
                    //TODO: Process Line
                }
            }
        }
