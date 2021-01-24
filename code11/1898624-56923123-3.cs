    [TestMethod]
    public void IEntitySupport()
    {
        // use IEntity and object
        IEntity bar = new Bar(1);
        Repository barRepository = new BarRepository();
        barRepository.Add(bar);
        var bar2 = barRepository.Get((object)1);
        Assert.AreSame(bar, bar2);
    }
    [TestMethod]
    public void TEntitySupport()
    {
        // use TEntity and TId
        var foo = new Foo("a");
        var fooRepository = new FooRepository();
        fooRepository.Add(foo);
        var foo2 = fooRepository.Get("a");
        Assert.AreSame(foo, foo2);
    }
