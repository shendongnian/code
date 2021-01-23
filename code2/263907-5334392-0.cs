    protected void Page_Load(object sender, EventArgs e)
    {
        AddOnPreRenderCompleteAsync(new BeginEventHandler(Thread_BeginEvent), new EndEventHandler(Thread_EndEvent));
    }
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        Response.Write(result);
    }
    private string result;
   
    IAsyncResult Thread_BeginEvent(object sender, EventArgs e, AsyncCallback cb, object extraData)
    {
        WaitCallback w = new WaitCallback(Thread_DoWork);
        return w.BeginInvoke(sender, cb, extraData, w);
    }
    void Thread_EndEvent(IAsyncResult ar)
    {
        WaitCallback w = ar.AsyncState as WaitCallback;
        if(w != null)
            w.EndInvoke(ar);
    }
    void Thread_DoWork(object state)
    {
        result = "";
        for (int i = 0; i < 10; i++)
        {
            result += "Threading! <br/><br/>";
            Thread.Sleep(500);
        }
    }
