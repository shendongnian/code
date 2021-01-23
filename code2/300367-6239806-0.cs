    class FooBase<T> where T: BarBase {
        public virtual T Bar { get; set; }
        public FooBase() { }
    }
    class Foo : FooBase<Bar> {
        public override Bar Bar { get; set; }
        public Foo() : base() {
            Bar = new Bar();
        }
    }
