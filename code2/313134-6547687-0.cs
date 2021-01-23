    public void Configure()
    {
        bool create = true;
        IKernel kernel = new StandardKernel();
        kernel.Settings.AllowNullInjection = true;
        kernel.Bind<IFoo>().ToMethod(ctx => create ? ctx.Kernel.Get<Foo>() : null);
        DependendsOnIFoo depFoo = kernel.Get<DependendsOnIFoo>();
    }
    private interface IFoo {}
    private class Foo : IFoo {}
    private class DependendsOnIFoo
    {
        public DependendsOnIFoo(IFoo foo) {}
    }
