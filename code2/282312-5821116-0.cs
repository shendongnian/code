    [ServiceContract]
    public interface IMessageBroker
    {
      [OperationContract]
      string Send(string message);
    }
