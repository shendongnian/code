    private EventHander _handler = null;
    
    public A()
    {        
        _handler = delegate( object sender, EventArgs ee)
            {          
            };
        ServiceAdapter.CompletedCallBackEvent += _handler;
    }
