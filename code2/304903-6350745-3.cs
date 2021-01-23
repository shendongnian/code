    [ExportMessageSender("EmailSender2")]
    public class EmailSender : IMessageSender
    {
      public void Send(string message)
      {
        Console.WriteLine(message);
      }
    }
