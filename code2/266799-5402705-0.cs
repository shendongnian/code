        private void cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            bg.RunWorkerAsync(cb.SelectedIndex);
        }
        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            int campaignID = (int)e.Argument;
            for (int i = 0; i < 100; i++)
            {
                int subscribers = new Random().Next(0, 100);
                bg.ReportProgress(subscribers);
                Thread.Sleep(30);
            }
        }
        private void bg_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pb.Value = e.ProgressPercentage;
        }
