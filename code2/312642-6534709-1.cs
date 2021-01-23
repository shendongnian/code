        private void button1_Click(object sender, EventArgs e)
        {
            var worker = new MyBackgroundWorker();
            worker.RunWorkerStarted += worker_RunWorkerStarted;
            worker.RunWorkerCompleted += worker_Completed;
            worker.RunWorkerAsync(new MethodInvoker(SomeLengthyOperation), null);
        }
        void worker_RunWorkerStarted(object sender, EventArgs e)
        {
           
        }
        void worker_Completed(object sender, EventArgs e)
        {
            MessageBox.Show("Worker completed");
        }
        private void SomeLengthyOperation()
        {
           Thread.Sleep(5000);
        }
