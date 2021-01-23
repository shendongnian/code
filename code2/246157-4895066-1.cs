    [Serializable]
    public class Foo: Dictionary<string, string> {
        public Foo() : base() { }
        public Foo(SerializationInfo info, StreamingContext context) : base(info, context) { }
        public Foo(int capacity) : base(capacity) { }
        public Foo(IEqualityComparer<string> comparer): base(comparer) {}
        public Foo(IDictionary<string,string> dictionary) : base(dictionary) { }
        public Foo(int capacity, IEqualityComparer<string> comparer) : base(capacity, comparer) { }
        public Foo(IDictionary<string, string> dictionary, IEqualityComparer<string> comparer) : base(dictionary, comparer) { }
    }
