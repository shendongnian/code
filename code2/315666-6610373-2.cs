    public class DBField<T>
    {
      private DBCommand getCommand;
    
      public T Value {get;set;}
      public T GetLastValue()
      {
         // Execute getCommand here
      }
      
      public DBField<T>(DBCommand GetCommand)
      {
        this.getCommand = GetCommand;
      }
    }
