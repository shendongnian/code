    abstract public class Base
    {
        abstract public string Foo { get; }
        abstract public string Bar { get; }
        abstract public string Baz { get; }
    }
    public class Derived : Base
    {
        public override string Foo { get { return "foo"; } }
        public override string Bar { get { return "bar"; } }
        public override string Baz { get { return "baz"; } }
    }
