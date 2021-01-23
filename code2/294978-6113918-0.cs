    public class Foo
    {
        protected IBlah Blah { get; private set; }
        ...
    }
    public class FooOnSteroids : Foo 
    {
        private new IBlahOnSteroids Blah { get { return (IBlahOnSteroids)base.Blah; } }
        ...
    }
