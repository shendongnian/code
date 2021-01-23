        public interface IConnectionType
    {
        ConnectionTypeEnum Connection{ get; set;}
    }
    public enum ConnectionTypeEnum
    {
       Undefined,
       Type1,
       Type2
    }
    public interface IPort<T> where T : IConnectionType
    {
    }
    public interface IConnection<T> where T : IConnectionType
    {
        IEnumerable<IPort<T>> Ports {get;set;}
    }
