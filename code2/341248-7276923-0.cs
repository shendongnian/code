        #region TableWorker Events
        void TableWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            bool done = false;
            GetSwitch();
            ProgressLabel.Visible = true;
            while (!done)
            {
                for (int i = 1; i <= 100; i++)
                {
                    Thread.Sleep(100);
                    TableWorker.ReportProgress(i);
                }
                done = Export.ExportDataTable(SaveFile, DataTable);
            }
        }
        void TableWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Progress.Style = ProgressBarStyle.Blocks;
            Progress.Value = e.ProgressPercentage;
            ProgressLabel.Text = "Writing File: " + e.ProgressPercentage.ToString() + "% Complete";
        }
        void TableWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Progress.Value = 100;
            ProgressLabel.Visible = false;
            Progress.Visible = false;
            //MessageBox.Show("Export Completed!");
            TableWorker.Dispose();
            ExportButton.Enabled = true;
            this.Close();
        }
        #endregion
