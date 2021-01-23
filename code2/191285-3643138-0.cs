    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    partial class MainForm
    {
        private CancellationTokenSource cancellationTokenSource;
        partial void startButton_Click(object sender, EventArgs e)
        {
            // Start the background task without error. 
            this.StartBackgroundTask(false);
            // Update UI to reflect background task. 
            this.TaskIsRunning();
        }
        partial void errorButton_Click(object sender, EventArgs e)
        {
            // Start the background task with error. 
            this.StartBackgroundTask(true);
            // Update UI to reflect background task. 
            this.TaskIsRunning();
        }
        partial void cancelButton_Click(object sender, EventArgs e)
        {
            // Cancel the background task. 
            this.cancellationTokenSource.Cancel();
            // The UI will be updated by the cancellation handler. 
        }
        private void StartBackgroundTask(bool causeError)
        {
            this.cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = this.cancellationTokenSource.Token;
            var progressReporter = new ProgressReporter();
            var task = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i != 100; ++i)
                {
                    // Check for cancellation  
                    cancellationToken.ThrowIfCancellationRequested();
                    Thread.Sleep(30); // Do some work.  
                    // Report progress of the work.  
                    progressReporter.ReportProgress(() =>
                    {
                        // Note: code passed to "ReportProgress" can access UI elements freely.  
                        this.progressBar.Value = i;
                    });
                }
                // After all that work, cause the error if requested. 
                if (causeError)
                {
                    throw new InvalidOperationException("Oops...");
                }
                // The answer, at last!  
                return 42;
            }, cancellationToken);
            // ProgressReporter can be used to report successful completion, 
            //  cancelation, or failure to the UI thread.  
            progressReporter.RegisterContinuation(task, () =>
            {
                // Update UI to reflect completion. 
                this.progressBar.Value = 100;
                // Display results. 
                if (task.Exception != null)
                    MessageBox.Show("Background task error: " + task.Exception.ToString());
                else if (task.IsCanceled)
                    MessageBox.Show("Background task cancelled");
                else
                    MessageBox.Show("Background task result: " + task.Result);
                // Reset UI. 
                this.TaskIsComplete();
            });
        }
    }
