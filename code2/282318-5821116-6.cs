    [Export(typeof(IMessageBroker)),
     ExportMetadata("Name", "SampleMessageBroker"),
     ExportMetadata("Channel", "Greetings")]
    public class SampleMessageBroker : IMessagerBroker
    {
      public string Send(string message)
      {
        return "Hello! " + message;
      }
    }
