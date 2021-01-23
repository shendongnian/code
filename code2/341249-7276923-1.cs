        private void EntireTableButton_Click(object sender, EventArgs e)
        {
            dialogResult = Export.SetSaveDialog(SaveFile, ".csv", "csv file (*.csv)|*.csv");
            if (dialogResult == DialogResult.OK)
            {
                TableWorker.RunWorkerAsync();
                this.Hide();
                ProgressLabel.Visible = true;
                ProgressLabel.Text = "Retrieving Data...";
                Progress.Style = ProgressBarStyle.Marquee;
                Progress.Visible = true;
                ExportButton.Enabled = false;
                while (TableWorker.IsBusy)
                {
                    Application.DoEvents();
                }
                Progress.Visible = false;
            }
        }
