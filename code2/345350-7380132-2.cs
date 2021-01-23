    [DataContract]
    public class ConsoleData
    {
        [DataMember]
        public double CurrentIndicator
        {
            get { return 22; }
            set { /* whatever */ }
        }
    }
    
    [ServiceContract]
    public interface IMBClientConsole
    {
        [OperationContract]
        ConsoleData GetData();
    }
