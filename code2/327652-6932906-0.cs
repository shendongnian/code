    public class MyServerClass : MarshalByRefObject
    {
       public override void InitializeLifetimeService ()
       {
          return null;
       }
    
       public string SendAndRecieve (string message)
       {
          return message + message;
       }
    }
