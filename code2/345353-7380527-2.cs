    [DataContract]
    public interface IConsoleData
    {
        [DataMember]
        double CurrentIndicator { get; set; }
    }
    
    public class ConsoleDataImpl : IConsoleData
    {
        public double CurrentIndicator { get; set; }
    }
    
    
    [ServiceContract]
    [KnownType(typeof(ConsoleDataImpl))]
    public interface IMBClientConsole
    {
        [OperationContract]
        IConsoleData GetData();
    }
    
    public class MBClientConsole : IMBClientConsole
    {
        public IConsoleData GetData()
        {
            return new IConsoleDataImpl() { CurrentIndicator = 22 };
        }
    }
