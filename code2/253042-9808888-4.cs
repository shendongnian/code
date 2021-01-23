    private List<IFoo> GenerateFooList(int max)
    {
        var fooList = new List<IFoo>();
    
        for (int i = 0; i < max; i++)
            fooList.Add(GenerateFoo());
    
        return fooList;
    }
    
    private IFoo GenerateFoo()
    {
        var foo = new Mock<IFoo>();
        foo.Setup(f => f.DoSomething()).Raises(f => f.myEvent += null, EventArgs.Empty);
        return foo.Object;
    }
