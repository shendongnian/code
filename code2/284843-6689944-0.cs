    public class RemoteDatabase
    {    
          // changed to private, referenced by CommandWay1
          private SqlCommand GetCommand(string query, object[] values)
          {
              /* GetCommand() code */ 
          }
    
          public Func<string, object[], SqlCommand> CommandWay1
          {
              get
              {
                 return (q,v) => GetCommand(q,v);
              }
          }
    
          // or, you could remove the above and just have this, 
          // with the code directly in the property
          public Func<string, object[], SqlCommand> CommandWay2
          {
              get
              {
                 return
                    (q,v) =>
                    {
                       /* GetCommand() code */ 
                    };
          }
    }
