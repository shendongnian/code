    [Test]
    public void NSubstituteOrderedTest() {
        // Arrange
        var provider = Substitute.For<IProvider>();
        var calculator = Substitute.For<ICalculator>();
        provider.GetData().Returns(4);
        calculator.Calculate(4).Returns(9);
        // Act
        var op = new Operator();
        op.Operate(provider, calculator);
        // Assert
        Received.InOrder(() =>
        {
            provider.GetData();
            calculator.Calculate(4);
        });
        Assert.That(op.Result, Is.EqualTo(9));
    }
