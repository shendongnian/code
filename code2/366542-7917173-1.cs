        private void Form1_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            List<string> items = new List<string>();
            items.Add("Starting");
            System.Threading.Thread.Sleep(2500);
            backgroundWorker1.ReportProgress(25, items.ToArray());
            items.Add("Halfway there");
            System.Threading.Thread.Sleep(2500);
            backgroundWorker1.ReportProgress(50, items.ToArray());
            items.Add("Almost there");
            System.Threading.Thread.Sleep(2500);
            backgroundWorker1.ReportProgress(75, items.ToArray());
            items.Add("Done");
            System.Threading.Thread.Sleep(2500);
            backgroundWorker1.ReportProgress(100, items.ToArray());
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange((string [])e.UserState);
            this.Text = e.ProgressPercentage.ToString();
        }
