    private void RvListen_OPT()
    {
       OnRvMessageReceived("RvListn_OPT()", new SigRvMessageEventArgs())
    }
    
    private void RvListen_FUT()
    {
       OnRvMessageReceived("RvListn_FUT()", new SigRvMessageEventArgs())
    }
    void OnRvMessageReceived(object sender, SigRvMessageEventArgs args)
    {
       if(sender.ToString() == "RvListn_OPT()"){
          // do work
       }
       else if(sender.ToString() == "RvListn_FUT()"){
          // do work
       }
    }
    
