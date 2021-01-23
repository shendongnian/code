    private void bw_DoWork( object sender, DoWorkEventArgs e )
        {
            try
            { 
                if( !backgroundWorkder.CancellationPending )
                {
                   //  ....
                }
             }
             catch
             {
                 if (bgWorker.WorkerSupportsCancellation && !bWorker.CancellationPending)
                 {
                     e.Cancel = true;
                     e.Result = "Give your error";
                     return;
                 }
             }
       }
