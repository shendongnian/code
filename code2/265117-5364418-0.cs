        private void button1_Click(object sender, EventArgs e) {
            button1.Enabled = false;
            backgroundWorker1.RunWorkerAsync();
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) {
            System.Threading.Thread.Sleep(2000);
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            button1.Enabled = true;
        }
