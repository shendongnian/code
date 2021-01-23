    public abstract class Test
    {
        public virtual void SomeMethod() {}
        //OR
        public abstract void SomeMethod();//MSDN says:
        //an abstract method is implicitly virtual
    }
    
    class A : Test
    {
        public sealed override SomeMethod()
        {
    
        }
    }
