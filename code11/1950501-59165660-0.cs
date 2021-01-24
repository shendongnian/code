        public int Count;
        private readonly object _countLock = new Object();
        private void TaskCallBack(Object ThreadNumber)
        {
            lock( _countLock )
            {
                ++Count;
                MessageBox.Show(Count.ToString());
            }
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                // this smells
                this.Count = 0;
                //// Queue the task.
                for (int x = 0; x < 10; x++)
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(TaskCallBack));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex);
            }
        }
