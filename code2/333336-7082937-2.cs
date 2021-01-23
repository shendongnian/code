    public class BaseConnection
    {
        public virtual void DoSomething() { ... }
    }
    
    public class MSSQLConnection: BaseConnection
    {
      public override void DoSomething() { ... }
    }
    
    public class XMLConnection: BaseConnection
    {
      public override void DoSomething() { ... }
    }
    
    public class OracleConnection: BaseConnection
    {
        public override void DoSomething() { ... }
    }
