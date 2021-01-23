    //Use this to hold the information that you want to log.
    public class LogRecord
    {
      private IEnumerable<object> values;
      public LogRecord(params object [] data)
      {
        LogTime = DateTime.Now;
        values = data;
      }
    
      public DateTime LogTime { get; set; }
      public IEnumerable<object> Values 
      { 
        get
        {
          yield return LogTime;
          foreach(var v in values) yield return v;
        }
      }
    }
    
    //
    private void MyLogic(MyClass LogObj)
    {
      var record = new LogRecord("Q", LogObj.Var1, LogObj.Var2, LogObj.Var3);
      MyLogger.Log(record);
    }
    
    class MyLogger
    {
      public void Log(LogRecord record)
      {
        //Do a bunch of threading stuff...
    
        string msg = string.Join(",", record.Values);
    
        //Write the message to the stream
      }
    }
