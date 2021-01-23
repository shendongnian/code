        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= 100; i++)
            {
                sb.AppendLine(i.ToString());
                backgroundWorker1.ReportProgress(i);
            }
            e.Result = sb.ToString();
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                textbox1.Text = e.Result.ToString();
                label1.Text = "All Done !";
                Cursor.Current = Cursors.Default;
            }
            else
            {
                label1.Text = e.Error.Message;
            }
        }
