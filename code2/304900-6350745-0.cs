    [Export(typeof(IMessageSender)), ExportMetadata("Name", "EmailSender1")]
    public class EmailSender : IMessageSender
    {
      public void Send(string message)
      {
        Console.WriteLine(message);
      }
    }
