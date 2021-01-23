        ProgressDialog dlg;
        private void RunProcess_Click(object sender, EventArgs e) {
            backgroundWorker1.RunWorkerAsync();
            using (dlg = new ProgressDialog()) {
                dlg.ShowDialog(this);
            }
            dlg = null;
            if (backgroundWorker1.IsBusy) backgroundWorker1.CancelAsync();
        }
