    public class MyService : IHostedService 
    {
        private DataType lastData;
        public DataType GetLastData()
        {
           return Volatile.Read(ref lastData);
        }
    
        public void ProcessNextPart()
        {
            lastData = newValue;
        } 
    }
