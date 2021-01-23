    public class ConsoleLogger : LoggerBase
    {
      public override void Write(object item)
      {
        Console.WriteLine(FormatObject(item));
      }
    }
    
