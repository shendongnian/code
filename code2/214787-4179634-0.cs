    ObjectUnderTest _objectUnderTest;
    
    [Setup] //Gets run before each test
    public void Setup() {
        var foo = new Mock<IFoo>(); //moq by default creates loose mocks
        _objectUnderTest = new ObjectUnderTest(foo.Object);
    }
    [Test]
    public void DoStuffToPushIntoState1ShouldCallFizz() {
        _objectUnderTest.DoStuffToPushIntoState1(); // this is various lines of code and setup
    
        foo.Verify(x => x.Fizz());
    }
    [Test]
    public void DoStuffToPushIntoState2ShouldntCallFizz() {
    {
        objectUnderTest.DoStuffToPushIntoState2(); // more lines of code
        foo.Verify(x => x.Fizz(), Times.Never());
    }
