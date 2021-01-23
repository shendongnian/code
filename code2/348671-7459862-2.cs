    using System;  
    using System.Collections.Generic;  
    using System.ComponentModel;  
    using System.Data;  
    using System.Drawing;  
    using System.Text;  
    using System.Windows.Forms;  
      
    namespace BackgroundWorker  
    {  
        public partial class Form1 : Form  
        {  
            public Form1()  
            {  
                InitializeComponent();  
      
                //mandatory. Otherwise will throw an exception when calling ReportProgress method  
                backgroundWorker1.WorkerReportsProgress = true;   
      
                //mandatory. Otherwise we would get an InvalidOperationException when trying to cancel the operation  
                backgroundWorker1.WorkerSupportsCancellation = true;  
            }  
      
            //This method is executed in a separate thread created by the background worker.  
            //so don't try to access any UI controls here!! (unless you use a delegate to do it)  
            //this attribute will prevent the debugger to stop here if any exception is raised.  
            //[System.Diagnostics.DebuggerNonUserCodeAttribute()]  
            private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)  
            {  
                //NOTE: we shouldn't use a try catch block here (unless you rethrow the exception)  
                //the backgroundworker will be able to detect any exception on this code.  
                //if any exception is produced, it will be available to you on   
                //the RunWorkerCompletedEventArgs object, method backgroundWorker1_RunWorkerCompleted  
                //try  
                //{  
                    DateTime start = DateTime.Now;  
                    e.Result = "";  
                    for (int i = 0; i < 100; i++)  
                    {  
                        System.Threading.Thread.Sleep(50); //do some intense task here.  
                        backgroundWorker1.ReportProgress(i, DateTime.Now); //notify progress to main thread. We also pass time information in UserState to cover this property in the example.  
                        //Error handling: uncomment this code if you want to test how an exception is handled by the background worker.  
                        //also uncomment the mentioned attribute above to it doesn't stop in the debugger.  
                        //if (i == 34)  
                        //    throw new Exception("something wrong here!!");  
      
                        //if cancellation is pending, cancel work.  
                        if (backgroundWorker1.CancellationPending)  
                        {  
                            e.Cancel = true;   
                            return;  
                        }  
                    }  
      
                    TimeSpan duration = DateTime.Now - start;  
                      
                    //we could return some useful information here, like calculation output, number of items affected, etc.. to the main thread.  
                    e.Result = "Duration: " + duration.TotalMilliseconds.ToString() + " ms.";  
                //}  
                //catch(Exception ex){  
                //    MessageBox.Show("Don't use try catch here, let the backgroundworker handle it for you!");  
                //}  
            }  
      
            //This event is raised on the main thread.  
            //It is safe to access UI controls here.  
            private void backgroundWorker1_ProgressChanged(object sender,   
                ProgressChangedEventArgs e)  
            {  
                progressBar1.Value = e.ProgressPercentage; //update progress bar  
                  
                DateTime time = Convert.ToDateTime(e.UserState); //get additional information about progress  
                  
                //in this example, we log that optional additional info to textbox  
                txtOutput.AppendText(time.ToLongTimeString());  
                txtOutput.AppendText(Environment.NewLine);              
            }  
            //This is executed after the task is complete whatever the task has completed: a) sucessfully, b) with error c)has been cancelled  
            private void backgroundWorker1_RunWorkerCompleted(object sender,   
                RunWorkerCompletedEventArgs e)  
            {  
                if (e.Cancelled) {  
                    MessageBox.Show("The task has been cancelled");  
                }  
                else if (e.Error != null)  
                {                  
                    MessageBox.Show("Error. Details: " + (e.Error as Exception).ToString());  
                }  
                else {  
                    MessageBox.Show("The task has been completed. Results: " + e.Result.ToString());  
                }  
                  
            }  
      
            private void btoCancel_Click(object sender, EventArgs e)  
            {  
                //notify background worker we want to cancel the operation.  
                //this code doesn't actually cancel or kill the thread that is executing the job.  
                backgroundWorker1.CancelAsync();  
            }  
      
            private void btoStart_Click(object sender, EventArgs e)  
            {  
                backgroundWorker1.RunWorkerAsync();  
            }  
        }  
    }  
