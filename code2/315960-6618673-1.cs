    SynchronazationContext ctx = null;
    void DoSomething()
    {
        ctx = SynchronazationContext.Current;
        Thread t = new Thread(new ThreadStart(ThreadProc));
        t.Start();
    }
    
    //This method run in separate Threads
    void ThreadProc()
    {
        //Some algorithm here
        SendOrPostCallback callBack  = new SendOrPostCallback(UpdatePic);
        ctx.Post(callBack, String.Format("Put here the pic path");
    }
    void UpdatePic(string _text)
    {  
        //This method run under the main method
       //In this method you should update the pic
    }
