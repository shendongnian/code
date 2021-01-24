    public class MyService : IHostedService 
    {
        private readonly object syncRoot = new object();
        private DataType lastData;
        public DataType GetLastData()
        {
           lock (syncRoot)
               return lastData;
        }
    
        public void ProcessNextPart()
        {
            lock (syncRoot)
                lastData = newValue;
        } 
    }
