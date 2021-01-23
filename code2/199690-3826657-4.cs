    public interface IReadableFoo
    {
      IMyValInterface MyVal{ get; }
    }
    
    public interface IWritableFoo : IReadableFoo
    {
      IMyValInterface MyVal{ set; }
    }
    
    public class Foo : IWritableFoo 
    {
      private ConcreteMyVal _myVal;
    
      public IMyValInterface MyVal
      {
        get { return _myVal; }
        set { _myVal = value as ConcreteMyVal; }
      }
    }
