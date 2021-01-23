    public class FooProvider : Provider<IFoo>
    {
        public override IFoo CreateInstance(IContext ctx)
        {
            // add here your special IFoo creation code
            return new Foo();
        }
    }
    kernel.Bind<IFoo>().ToProvider<FooProvider>();
