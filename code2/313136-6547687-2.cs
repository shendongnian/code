    public void Configure()
    {
        bool heavy = true;
        IKernel kernel = new StandardKernel();
        kernel.Bind<IFoo>()
         .ToMethod(ctx => heavy ? ctx.Kernel.Get<HeavyFoo>() : (IFoo)new DummyFoo());
        DependendsOnIFoo depFoo = kernel.Get<DependendsOnIFoo>();
    }
    private interface IFoo {}
    private class HeavyFoo : IFoo {}
    private class DummyFoo : IFoo { }
    private class DependendsOnIFoo
    {
        public DependendsOnIFoo(IFoo foo) {}
    } 
