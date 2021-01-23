    class Foo : FooBase
    {
        public override BarBase Bar { get; set; }
        public Foo() : base()
        {
            // populate our modified property with the derived class
            Bar = new Bar();
            //base.Bar = Bar; // I don't want to do this, but how can I avoid it?
        }
    }
