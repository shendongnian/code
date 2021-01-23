    SynchronazationContext ctx = null;
    void DoSomething()
    {
        ctx = SynchronazationContext.Current;
        //Some algorithm here
        this.UpdatePic("Success !");
    }
    void ThreadProc()
    {
        SendOrPostCallback callBack  = new SendOrPostCallback(UpdatePic);
        ctx.Post(callBack, String.Format("Put here the pic path");
    }
    void UpdatePic(string _text)
    {  
        //This method run under the main method
    }
