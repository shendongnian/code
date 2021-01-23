    public class BaseClass<T>
    where T : BaseObject
    {
        public T[] Objects;
    
        public virtual void DoStuff()
        {
            // use the Objects
        }
    }
    
    public class DerivedClass : BaseClass<DerivedObject>
    {
        public override void DoStuff()
        {
            // Do stuff unique to the derived.
            base.DoStuff();
        }
    }
