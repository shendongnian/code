        private void button1_Click(object sender, EventArgs e) {
            timer1.Enabled = true;
            backgroundWorker1.RunWorkerAsync();
        }
        private void timer1_Tick(object sender, EventArgs e) {
            timer1.Enabled = false;
            myControl1.Visible = true;
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            timer1.Enabled = myControl1.Visible = false;
        }
