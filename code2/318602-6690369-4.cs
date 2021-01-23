    // Somewhere in the form1 code:
    Server.newConnectionEvent += ConnectionEVentHandler(myMethod)
    public void myMethod()
    {
      //Event method called from another thread
      //can only do things here that do affect the UI!
      this.Dispatcher.Invoke(CalledOnUIThread);
    }
        
    public void CalledOnUIThread()
    {
      //Handle event on UI thread here
      //Can do things here that affect the UI
    }
