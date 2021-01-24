    [Fact]
    public void Test3()
    {
        var testScheduler = new TestScheduler();
        var foo = new Foo(testScheduler);
        foo.TestCommand.Execute().Subscribe();
        testScheduler.Start(); // YEAY
    }
