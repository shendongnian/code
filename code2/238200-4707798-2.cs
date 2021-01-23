    private void Worker_RunWorkerCompleted(object sender, 
       RunWorkerCompletedEventArgs e)
    {
       // always check e.Error first, in case PerformSearch threw an exception.
       if (e.Error != null)
       {
          // in your version, you want to do real exception handling, not this.
          throw e.Error.InnerException;  
       }
       // if the worker was cancelled, it's because the user typed some more text, and
       // we want to launch a new search using what's currently in the Text property.
       if (e.Cancelled)
       {
          Worker.RunWorkerAsync(Text);
          return;
       }
       // if the worker wasn't cancelled, e.Result contains the results of the search.
       DisplayResults((IEnumerable<string> e.Result);
    }
