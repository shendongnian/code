    public void CalledFromOtherThread()
    {
      //Event method called from another thread
      this.Dispatcher.Invoke(CalledOnUIThread);
    }
        
    public void CalledOnUIThread()
    {
      //Handle event on UI thread here
    }
