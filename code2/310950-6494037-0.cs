    public class BaseClass
    {
        // this method forces that structure upon the subclasses
        public void Foo()
        {
            if(result > 0)
            {
                DoFoo();
            }
        }
        // this is the method that subclasses override
        protected abstract void DoFoo();
    }
    public class DerivedClass : BaseClass
    {
        public override DoFoo()
        {
            // now you write the code here
        }
    }
