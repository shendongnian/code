    // delegate to update progress
    public delegate void ProgressChangedEventHandler(Object sender, ProgressEventArgs e);
    
    // Event added to your worker class.
    public event ProgressChangedEventHandler ProgressUpdateEvent
    
    // Method to raise the event
    public void UpdateProgress(object sender, ProgressEventArgs e)
    {
       ProgressChangedEventHandler handler;
       lock (progressUpdateEventLock)
       {
          handler = progressUpdateEvent;
       }
    
       if (handler != null)
          handler(sender, e);
    }
