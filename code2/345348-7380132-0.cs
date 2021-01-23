    [DataContract]
    public class ConsoleData
    {
        [DataMember]
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
