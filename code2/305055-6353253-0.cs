    // can be inherited only by classes in the same assembly
    public abstract class A
    {
        protected internal A() { }
    }
    // can't be inherited
    public sealed class B : A
    {
    }
