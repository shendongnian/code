        string[,] TestData = new string[30000, 100];
        List<string> TestDataList;
        private static Random random = new Random();
        CancellationTokenSource cts = new CancellationTokenSource();
        CancellationToken cancellationToken;
        private void BtnStart_Click(object sender, EventArgs e)
        {
            try
            {
                this.showWorkingLabel.Text = "Work start";
                System.Threading.SynchronizationContext.SetSynchronizationContext(new WindowsFormsSynchronizationContext());
                BackgroundWorker bw = new BackgroundWorker();
                bw.WorkerSupportsCancellation = true;
                bw.DoWork += new DoWorkEventHandler(bw_DoWork);
                // Cancel worker when the CancellationTokenSource is canceled.
                cancellationToken = cts.Token;
                cancellationToken.Register(bw.CancelAsync);
                bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_Complete);
                bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong.\nError:" + ex.Message);
            }
        }
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            cancellationToken.ThrowIfCancellationRequested();
            this.TestDataList = this.TestData
                .Cast<string>()
                .Select((s, i) => new { GroupIndex = i / 100, Item = s.Trim().ToLower() })
                .GroupBy(g => g.GroupIndex)
                .Select(g =>
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    return string.Join(",", g.Select(x => x.Item));
                })
                .ToList();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // I want to cancel the work with this button
            cts.Cancel();
            // Then show
            this.showWorkingLabel.Text = "Work Cancelled";
        }
