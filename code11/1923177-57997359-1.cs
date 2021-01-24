    [TestMethod]
    public void TestDoWork_Should_Return_False() {
        //Arrange
        var subject = Substitute.ForPartsOf<MyClass>(Substitute.For<ILogger>());
        bool expected = false;
        subject.Configure().NeedsMoreWork(Arg.Any<Item>(), out Arg.Any<Part>()).Returns(expected);
    
        //Act
        bool actual = subject.DoWork(new Item());
    
        //Assert - FluentAssertions
        actual.Should().Be(expected);
    }
