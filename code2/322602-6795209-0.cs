       void DoWork(object sender, DoWorkEventArgs e)
       {
          //...
          e.Result = stderr;
       }
    
       void WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
       {
          if (e.Error != null) DisplayError(e.Error);
          else _tbLog.Text += (string)e.Result;
       }
