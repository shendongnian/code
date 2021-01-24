    public class NetworkService
        {
            private readonly SynchronizationContext currContext;
            public NetworkService()
            {
                this.currContext = SynchronizationContext.Current;
            }
         
            private void OnNetworkAvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
            {
                try
                {
                    CodeThatCanApparentlyThrow();
                }
                catch (Exception exception)
                {
                    this.currContext.Post(s => throw exception, null); // this will propagate your exception into main thread
                }
    
            }
        }  
  
