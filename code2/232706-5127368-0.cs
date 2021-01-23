    [Test]
    public void WriteShouldBeCalledWithCorrectArguments()
    {
        // Arrange
        var mock = MockRepository.GenerateMock<ISomeInterface>();
        var sut = new SomeClass(mock);
        // Act
        sut.DoSomething();
        // Assert
        mock.AssertWasCalled(x => x.Write(Arg<string>.Matches(s => Equal(s, "hello"))));
    }
    private static bool Equal(string s1, string s2)
    {
        Assert.That(s1, Is.EqualTo(s2), "Unexpected argument");
        return true;
    }
