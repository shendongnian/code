    interface IFoo
    {
      // no trace here
    }
    
    class FooBase : IFoo
    {
    #if TRACE
        public abstract void DoIt();
    #endif
    }
    
    class Foo : FooBase
    {
    #if TRACE
        public override void DoIt() { /* do something */ }
    #endif
    }
