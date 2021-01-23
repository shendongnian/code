    abstract public class Base
    {
        public abstract string Foo { get; }
        public abstract string Bar { get; }
        public abstract string Baz { get; }
    }
    public class Derived : Base
    {
        public override string Foo { get { return "foo"; } }
        public override string Bar { get { return "bar"; } }
        public override string Baz { get { return "baz"; } }
    }
