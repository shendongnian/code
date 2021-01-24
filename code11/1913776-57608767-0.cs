    public class GenericFoo<TBar> : Foo {
        public TBar Data { get; private set; }
        private GenericFoo() { }
        public GenericFoo(TBar data) {
            Data = data;
        }
        [JsonConstructor]
        public GenericFoo(TBar data, params string[] someStrings) : this(data) {
            SomeStrings = someStrings.ToList();
        }
    }
