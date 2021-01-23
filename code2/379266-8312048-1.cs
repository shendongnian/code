    public class FooFactory : FactoryConverter<Foo>
    {
        public FooFactory(Bar bar)
        {
            this.Bar = bar;
        }
        public Bar Bar { get; private set; }
        public override Foo Create(Type objectType, Dictionary<string, string> arguments)
        {
            return new Foo(Bar, arguments["X"], arguments["Y"]);
        }
    }
