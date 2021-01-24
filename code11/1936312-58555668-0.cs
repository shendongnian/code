    [Fact]
    public void Should_Throw_InvalidOperationException_If_...()
    {
        // Arrange
        var resolver = new SomeResolver();
        var foo = new Foo();
    
        Action act = () => resolver.DoSomething(foo);
    
        // Act & Assert     
        act.ShouldThrow<InvalidOperationException>().WithMessage("...");
    }
