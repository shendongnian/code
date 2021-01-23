    private static void bckWrkSocket_DoWork(object sender, DoWorkEventArgs e)
    {
        var timer = new Timer(x => 
        {
           lock (file)
           {
              // close old file and open new file                    
           }
        }, null, 0, (int)e.Argument);
            
        while(true)
        {
            if (bckWrkSocket.CancellationPending) { e.Cancel = true; return; }
            // check socket etc. 
        }
    }
