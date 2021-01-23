    interface IFooBarRepository : IRepository<Foo>, IRepository<Bar>
    {
        IRepository<Foo> FooGetter { get; }
        IRepository<Bar> BarGetter { get; }
    }
