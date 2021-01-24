    using System.Runtime.CompilerServices;
    public class MyService : IHostedService 
    {
        private readonly object syncRoot = new object();
        private StrongBox<DataType> lastData;
        public DataType GetLastData()
        {
            return lastData.Value;
        }
    
        public void ProcessNextPart()
        {
            lastData = new StrongBox<DataType>(newValue);
        } 
    }
