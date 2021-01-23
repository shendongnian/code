    public class Base
    {
        // You must pick one option below
        // if you have a default value in the base class
        public virtual int x { get { return 7; /* magic default value */} }
        // if you don't have a default value
        // if you choose this alternative you must also make the Base class abstract
        public abstract int x { get; }
    }
    public class DerivedA : Base
    {
        public override int x { get { return 5; } }
    }
    public class DerivedB : Base
    {
        public override int x { get { return 10; } }
    }
