    public class SomethingThatNeedsNamedInstance
    {
       IPersonFactory _factory;
       IPerson _personInstance;
    
       public SomethingThatNeedsNamedInstance(IPersonFactory factory)
       {
          this._factory = factory; // regular DI greedy constructor, setup in registry.
       }
    
       public void DoSomething()
       {
           this._personInstance = _factory.GetPersonInstance("Customer");
           _personInstance.CallSomeMethod();
       }
    }
