    public delegate void BackgroundMethod()
    
    public void HandleUITrigger(object sender, EventArgs e)
    {
       //we'll assume the user does something to trigger this wait.
       
       //set up a BackgroundMethod delegate to do our time-intensive task
       BackgroundMethod method = DoHeavyLifting;
    
       //The Delegate.BeginInvoke method schedules the delegate to run on 
       //a thread from the CLR's ThreadPool, and handles the callback.
       method.BeginInvoke(HeavyLiftingFinished, null);
       //The previous method doesn't block the thread; the main thread will move on
       //to the next message from the OS, keeping the app responsive.
    }
    
    public void DoHeavyLifting()
    {
       //Do something incredibly time-intensive
       Thread.Sleep(5000);
    
       //Notice we don't have to know that we're being run in another thread,
       //EXCEPT this method cannot update the UI directly; to update the UI
       //we must call Control.Invoke() or call a method that Invokes itself
       ThreadSafeUIUpdate();
    }
    
    public void ThreadSafeUIUpdate()
    {
       //A simple, thread-safe way to make sure that "cross-threading" the UI
       //does not occur. The method re-invokes itself on the main thread if necessary
       if(InvokeRequired)
       {
          this.Invoke((MethodInvoker)ThreadSafeUIUpdate);
          return;
       }
    
       //Do all your UI updating here.
    }
    
    public void HeavyLiftingFinished()
    {
       //This method is called on the main thread when the thread that ran 
       //DoHeavyLifting is finished. You can call EndInvoke here to get
       //any return values, and/or clean up afterward.
    }
