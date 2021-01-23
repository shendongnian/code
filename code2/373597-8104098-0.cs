                   backgroundWorker1.WorkerSupportsCancellation = true;
    
      private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            mf = new MainForm(); //inside constructor,code of data loading in gridview
        while (!(sender as System.ComponentModel.BackgroundWorker).CancellationPending)
                {
                    mf .Refresh();
                }
             mf .Close();
            
              e.Result = mf ;
        }
