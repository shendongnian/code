    // Kick off thread
    Task.Factory.StartNew(delegate{
         foreach(var x in files) {
             // Do stuff
    
             // Update calling thread's UI
             Invoke((Action)(() => {
                  progressBar.PerformStep();
             }));
         }
    }
