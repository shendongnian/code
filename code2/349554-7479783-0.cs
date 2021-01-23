     BackgroundWorker folderWorker = new BackgroundWorker();
     folderWorker.WorkerReportsProgress = true;
     folderWorker.WorkerSupportsCancellation = true;
     folderWorker.DoWork += FolderWorker_DoWork;
     folderWorker.ProgressChanged += FolderWorker_ProgressChanged;
     
     folderWorker.RunWorkerAsync();
     void FolderWorker_DoWork(object sender, DoWorkEventArgs e)
     {
          BackgroundWorker worker = (BackgroundWorker)sender;
  
          while(!worker.CancellationPending)
          {
               DateTime lastAccess = Directory.GetLastAccessTime(DIRECTORY_PATH);
               //Check to see if lastAccess falls between the last time the loop started
               //and came to end.
               if(/*your check*/)
               {
                    object state;  //Modify this if you need to send back data.
                    worker.ReportProgress(0, state);
               }
          }
     }
     void FolderWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
     {
          //Take action here from the worker.ReportProgress being invoked.
     }
    
    
