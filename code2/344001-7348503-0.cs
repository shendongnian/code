    public class YourForm : Form
    {
      private Thread WorkerThread;
      private volatile bool KillThreads = false;
    
      private void YourForm_Closing(object sender, FormClosingEventArgs args)
      {
        // Do a fast check to see if the worker thread is still running.
        if (!WorkerThread.Join(0))
        {
          args.Cancel = true; // Cancel the shutdown of the form.
          KillThreads = true; // Signal worker thread that it should gracefully shutdown.
          var timer = new System.Timers.Timer();
          timer.AutoReset = false;
          timer.SynchronizingObject = this;
          timer.Interval = 1000;
          timer.Elapsed = 
            (sender, args) =>
            {
              // Do a fast check to see if the worker thread is still running.
              if (WorkerThread.Join(0)) 
              {
                // Reissue the form closing event.
                Close();
              }
              else
              {
                // Keep restarting the timer until the worker thread ends.
                timer.Start();
              }
            };
          timer.Start();
        }
      }    
    }
