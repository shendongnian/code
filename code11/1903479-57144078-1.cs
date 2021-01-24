    Class CleintClass{
    IWebSocketCaller  _caller; 
     ClientClass(IWebSocketCaller caller)
     { 
        this._caller = caller; 
     }
     Result GetData()
     {
        return  this._caller.GetData();
      }
    }
