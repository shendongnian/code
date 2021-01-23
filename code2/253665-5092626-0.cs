    public class ClassThatUseInjection
    {
        private readonly SomeClass _injectedClass;
        public ClassThatUseInjection(): this(new SomeClass()) {}
        internal ClassThatUseInjection(SomeClass injectedClass)
        {
            _injectedClass = injectedClass;
        }
    }
    public class SomeClass
    {
        public object SomeProperty { get; set; }
    }
