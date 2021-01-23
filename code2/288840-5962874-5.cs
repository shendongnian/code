    [TestMethod]
    public void SomeTestMethod()
    {
        // Arrange
        int expected = 23;
        var handler = new FakeHandler<MyCommand>();
        var service = new SomeService(handler );
        // Act
        service.ExecuteSomeCommand();
        // Assert
        Assert.AreEqual(expected, handler.HandledCommand.SomeInt);
    }
