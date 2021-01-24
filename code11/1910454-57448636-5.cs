    public abstract class DecoratorBase : IDecorated
    {
      private IDecorated decorated;
    
      // The decorator should always accept an abstract type 
      // or interface of the type to be decorated
      public DecoratorBase(IDecorated decorated)
      {
        this.decorated = decorated;
      }
    
      public void DoSomething()
      {
        // Delegate calls to the decorated class instance and ...
        this.decorated.DoSomething();
    
        // ... add functionality by invoking additional members. 
        // Making this member abstract adds customization for subtypes
        DoSomethingToExtendTheDecoratedBehavior();
      }
    
      public object DoSomethingDecoratorSpecific()
      {
      }
    
      protected abstract void DoSomethingToExtendTheDecoratedBehavior();
    }
