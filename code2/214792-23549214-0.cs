    [Test]
    public void Justification()
    {
        var foo = new Mock<IFoo>(MockBehavior.Loose);
        foo.Setup(x => x.Fizz());
    
        var objectUnderTest = new ObjectUnderTest(foo.Object);
    
        objectUnderTest.DoStuffToPushIntoState1(); // this is various lines of code and setup
    
        foo.Verify(x => x.Fizz());
    
        foo.ResetCalls(); // Reset the verification here with this glorious method
    
        objectUnderTest.DoStuffToPushIntoState2(); // more lines of code
    
        foo.Verify(x => x.Fizz(), Times.Never());
    }
