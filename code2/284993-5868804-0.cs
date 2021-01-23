    public delegate void PerformSomeActionDelegate();
    
    public void DoSomeThingInAThread()
    {
        // this code is executed by a thread
        if (this.InvokeRequired)
        {
            this.Invoke(new PerformSomeActionDelegate(MyAction));
        }
        else
        {
            MyAction();
        }
    }
    
    public void MyAction()
    {
        // update your controls here
    }
