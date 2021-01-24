    [Fact]
    public void VerifyAllPropertiesHaveBeenConsumedInTemplate()
    {
        var mockMailObject = new Mock<IMailObject>();
        var template = "yourTemplateOrMethodThatReturnsYourTemplate";
        var result = mergeTemplate(template, mockMailObject.Object);
        mockMailObject.VerifyGet(m => m.Username, Times.Once);
        mockMailObject.VerifyGet(m => m.SubscriptionID, Times.Once);
        mockMailObject.VerifyGet(m => m.MessageTime, Times.Once);
        mockMailObject.VerifyGet(m => m.Subject, Times.Once);
    }
