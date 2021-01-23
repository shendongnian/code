    public abstract class LoggerBase
    {
      public abstract void Write(object item);
      
      protected virtual object FormatObject(object item)
      {
        return item;
      }
    }
    
