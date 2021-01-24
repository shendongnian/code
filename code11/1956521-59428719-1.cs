    public abstract class MyBase
    {
        public virtual void MyVirtualMethod() { }
        public virtual void MyOtherVirtualMethod() { }
        public abstract void MyAbtractMethod();
    }
    public class MyDerived : MyBase
    {
        // When overriding a virtual method in MyBase, we use the override keyword.
        public override void MyVirtualMethod() { }
        // If we want to hide the virtual method in MyBase, we use the new keyword.
        public new void MyOtherVirtualMethod() { }
        // Because MyAbtractMethod is abstract in MyBase, we have to override it: 
        // we can't hide it with new.
        // For consistency with overriding a virtual method, we also use the override keyword.
        public override void MyAbtractMethod() { }
    }
