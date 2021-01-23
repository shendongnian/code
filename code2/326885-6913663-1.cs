    class GrandParent
    {
        public void Foo()
        {
            // base logic that should always run here:
            // ...
            this.DoFoo(); // call derived logic
        }
        protected virtual void DoFoo() { }
    }
    
    class Parent : GrandParent
    {
        protected override void DoFoo()
        {    
           // Do additional work (no need to call base.DoFoo)
        }
    }
    
    class Child : Parent
    {
        protected override void DoFoo()
        {  
            // Do additional work (no need to call base.DoFoo)
        }
    }
