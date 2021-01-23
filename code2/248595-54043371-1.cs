    [Test]
    public async Task ShouldProcessDiscountOrder()
    {
        // Arrange
        var saga = new YourSaga
        {
            Data = new YourSagaData()
        };
        var context = new TestableMessageHandlerContext();
        var yourCommand = new MyCommandOrEvent
        {
            propA = 1
        };
        // Act
        await saga.Handle(yourCommand, context)
            .ConfigureAwait(false);
        // Assert
        var processMessage = (OutputTypeReturnedByHandle)context.SentMessages[0].Message;
        Assert.AreEqual(123, processMessage.Something);
    }
