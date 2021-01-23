    class Server
    {
       public event EventHandler ServerStarted;
    
       protected virtual void OnServerStarted()
       {
           var handler = this.ServerStarted;
           if(handler != null)
           {
               handler(this,EventArgs.Empty);
           }
       }
    
       public void Start()
       {
            listen = true;
            this.listenThread.Start();
            OnServerStarted();
       }
    }
