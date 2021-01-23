    [Test]
    public async Task ShouldProcessDiscountOrder()
    {
        // Arrange
        var saga = new YourSaga
        {
            Data = new YourSagaData()
        };
        var context = new TestableMessageHandlerContext();
        var discountOrder = new SubmitOrder
        {
            CustomerId = Guid.NewGuid(),
            OrderId = Guid.NewGuid(),
            TotalAmount = 1000
        };
        // Act
        await saga.Handle(discountOrder, context)
            .ConfigureAwait(false);
        // Assert
        var processMessage = (ProcessOrder)context.SentMessages[0].Message;
        Assert.AreEqual(900, processMessage.TotalAmount);
    }
