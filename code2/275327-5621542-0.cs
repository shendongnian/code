    class ServerClass : IfaceClient2Server
    {
       public event EventHandler eventHappened;
       IfaceServer2Client callback;
       
       public ServerClass ()
       {
          callback = OperationContext.Current.GetCallbackChannel<IfaceServer2Client>();
       }
       
       ...
    }
