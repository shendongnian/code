    // you can define a delegate with the signature you want
    public delegate void PerformSomeActionDelegate();
    public void SomeMethod()
    {
        //this method is executed by the background worker
        InvokeUpdateControls();
    }
    
    public void InvokeUpdateControls()
    {
        if (this.InvokeRequired)
        {
            this.Invoke(new PerformSomeActionDelegate(MyAction));
        }
        else
        {
            MyAction();
        }
    }
    
    private void UpdateControls()
    {
        // update your controls here
    }
