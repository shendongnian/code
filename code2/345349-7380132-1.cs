    [DataContract]
    public class ConsoleData
    {
        [OperationContract]
        public double GetCurrentIndicator()
        {
            return 22;
        }
    }
    
    [ServiceContract]
    public interface IMBClientConsole
    {
        [OperationContract]
        ConsoleData GetData();
    }
