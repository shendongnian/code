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
    [...]
    public void SomeFunction(IReadableFoo fooVar)
    {
      // Cannot modify fooVar, excellent!
    }
    public void SomeOtherFunction(IWritableFoo fooVar)
    {
      // Can modify fooVar, take care!
    }
