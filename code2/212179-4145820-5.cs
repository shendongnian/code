    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void SomeTest()
    {
        // Arrange
        var invalidArgs = CreateValidArgs();
        invalidArgs.Property = "Invalid value";
        var service = CreateNewService(invalidArgs);
        // Act
        service.Operation();
    }
