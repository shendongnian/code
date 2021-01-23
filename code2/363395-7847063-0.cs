    private void button1_Click(object sender, EventArgs e)
        {
            var e1 = new System.Threading.AutoResetEvent(false);
            var e2 = new System.Threading.AutoResetEvent(false);
            var e3 = new System.Threading.AutoResetEvent(false);
            backgroundWorker1.RunWorkerAsync(e1);
            backgroundWorker2.RunWorkerAsync(e2);
            backgroundWorker3.RunWorkerAsync(e3);
            
            // Keep the UI Responsive
            ThreadPool.QueueUserWorkItem(x =>
            {
                // Wait for the background workers
                e1.WaitOne();
                e2.WaitOne();
                e3.WaitOne();
                MethodThatNotifiesIamFinished();
            });
            //Merge Code
        }
        void BackgroundWorkerMethod(object obj)
        {
            var evt = obj as AutoResetEvent;
            //Do calculations
            etv.Set();
        }
