    public A()
    {
        CompletedCallCallBackEventHander _handler = delegate( object sender, EventArgs ee)
            {          
            };
        
        ServiceAdapter.CompletedCallBackEvent += _handler;
    }
