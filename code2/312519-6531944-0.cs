    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class MyService : IMyService
    {
        private Object syncObject = new Object();
    
        public void MyServiceOperation()
        {
            lock (this.syncObject)
            {
                // Service implementation
            }
        }
    }
