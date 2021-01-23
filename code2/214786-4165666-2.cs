    [Fact]
    public void Test()
    {
        var foo = new Mock<IFoo>(MockBehavior.Loose);
    
        foo.Object.Fizz();
        foo.Verify(x => x.Fizz(), Times.Once(), "Failed After State 1");
                
        // stuff here
        foo.Object.Fizz();
        foo.Verify(x => x.Fizz(), Times.Once(), "Failed after State 2"); 
    }
