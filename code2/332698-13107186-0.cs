    public class Service : IMyService
    {
         public bool CallService()
    	 {
    	       IMyServiceCallback callback = OperationContext.Current.GetCallbackChannel<IMyServiceCallback>();
    		   Task.Factory.StartNew((cb) => cb.NotifyClient(), callback);
    	 }
    }
