    public BackgroudWorker()
            {
                InitializeComponent();
                backgroundWorker = ((BackgroundWorker)this.FindResource("backgroundWorker"));
            }
    
            private int DoSlowProcess(int iterations, BackgroundWorker worker, DoWorkEventArgs e)
            {            
                int result = 0;
                for (int i = 0; i <= iterations; i++)
                {
                    if (worker != null)
                    {
                        if (worker.CancellationPending)
                        {
                            e.Cancel = true;
                            return result;
                        }
                        if (worker.WorkerReportsProgress)
                        {
                            int percentComplete =
                            (int)((float)i / (float)iterations * 100);
                            worker.ReportProgress(percentComplete);
                        }
                    }
                    Thread.Sleep(100);
                    result = i;
                }
                return result;
            }
    
            private void startButton_Click(object sender, RoutedEventArgs e)
            {
                int iterations = 0;
                if (int.TryParse(inputBox.Text, out iterations))
                {
                    backgroundWorker.RunWorkerAsync(iterations);
                    startButton.IsEnabled = false;
                    cancelButton.IsEnabled = true;
                    outputBox.Text = "";
                }
    
            }
    
            private void cancelButton_Click(object sender, RoutedEventArgs e)
            {
                // TODO: Implement Cancel process
                this.backgroundWorker.CancelAsync();
            }
    
            private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
            {
               // e.Result = DoSlowProcess((int)e.Argument);
    
                var bgw = sender as BackgroundWorker;
                e.Result = DoSlowProcess((int)e.Argument, bgw, e);
            }
    
            private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                workerProgress.Value = e.ProgressPercentage;
            }
    
            private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Error != null)
                {
                    MessageBox.Show(e.Error.Message);
                }
                else if (e.Cancelled)  // added this condition for cacellation process
                {
                    outputBox.Text = "Canceled";
                    workerProgress.Value = 0;
                }
                else
                {
                    outputBox.Text = e.Result.ToString();
                    workerProgress.Value = 0;  // Added for progress Bar
                }
                startButton.IsEnabled = true;
                cancelButton.IsEnabled = false;
            }
