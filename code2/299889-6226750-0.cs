    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    
    namespace BackgroundWorkerSimple
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                backgroundWorker1.WorkerReportsProgress = true;
                backgroundWorker1.WorkerSupportsCancellation = true;
            }
    
            private void startAsyncButton_Click(object sender, EventArgs e)
            {
                if (backgroundWorker1.IsBusy != true)
                {
                    // Start the asynchronous operation.
                    backgroundWorker1.RunWorkerAsync();
                }
            }
    
            private void cancelAsyncButton_Click(object sender, EventArgs e)
            {
                if (backgroundWorker1.WorkerSupportsCancellation == true)
                {
                    // Cancel the asynchronous operation.
                    backgroundWorker1.CancelAsync();
                }
            }
    
            // This event handler is where the time-consuming work is done.
            private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
            {
                BackgroundWorker worker = sender as BackgroundWorker;
    
                // Excessive comuptation goes here, you can report back via this:
                worker.ReportProgress(progressInPercent, additionalProgressAsObject);
            }
    
            // This event handler updates the progress.
            private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                resultLabel.Text = (e.ProgressPercentage.ToString() + "%");
            }
    
            // This event handler deals with the results of the background operation.
            private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Cancelled == true)
                {
                    resultLabel.Text = "Canceled!";
                }
                else if (e.Error != null)
                {
                    resultLabel.Text = "Error: " + e.Error.Message;
                }
                else
                {
                    resultLabel.Text = "Done!";
                }
            }
        }
    }
