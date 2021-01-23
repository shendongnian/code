    public class ConsoleLogger : LoggerBase
    {
      public override void Write(object item)
      {
        Console.WriteLine(FormatObject(item));
      }
      
      protected override object FormatObject(object item)
      {
        return item.ToString().ToUpper();
      }
    }
    
