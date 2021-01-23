    preparemodule()
    {
      ProcessObj = new Process();
      ProcessObj.StartInfo.FileName = ApplicationPath;
      ProcessObj.StartInfo.Arguments = ApplicationArguments;
    }
    void run_Click(object sender, EventArgs e)
    {
      preparemodule();
      backgroundWorker1.RunWorkerAsync(ProcessObj);
    }
    void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
      int i=0;
      ProcessObj.Start();
      while (checkifexists("notepad", 0) == true)
      {
        i++;
        label5.Text = "Status: notepad running... " + progressBar1.Value.ToString() + "%";
        Thread.Sleep(3000);
        backgroundWorker1.ReportProgress(i);
        if ((backgroundWorker1.CancellationPending == true))
        {
          e.Cancel = true;
        }
      }
    }
    void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage <= 100)
            {
                progressBar1.Value = e.ProgressPercentage;
            }
        }
     void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           
            label5.Text = "Status: Done";
        }
     void cancel_Click(object sender, EventArgs e)
        {     
            backgroundWorker1.CancelAsync();
        }
