    this.backgroundWorker1.WorkerReportsProgress = true;
    this.backgroundWorker1.WorkerSupportsCancellation = true;
    this.backgroundWorker1.DoWork += new   System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
    this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
    this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
    private class Progress
    {
       public string Status { get; set; }
       public Progress(string status)
       {
          Status = status;
       }
    }
    
    //...
    
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
       while(myWork)
       {
          if(e.CancellationPending)
          {
             e.Cancel = true;
             break;
          }
          
          int p = //...percentage calc
          backgroundWorker1.ReportProgress(p, new Progress("My message...")));
       }
       
       e.Cancel = false;
    }
        
    void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
    {
            Progress p = (Progress)e.UserState;
            lStatus.Text = p.Status;
            progressBar.Value = e.ProgressPercentage;
    }
