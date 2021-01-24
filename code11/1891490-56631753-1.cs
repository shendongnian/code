    [Fact]
    public void it_Should_add_information_successfully_and_returns_200_status_result()
    {
        // Arrange
        var expected = new AddPropertyCommand();
        _mediatorMock.Setup(x => x.Send(It.IsAny<AddPropertyCommand>())).Returns(true);
        // Act
        var actionResult = _it.AddProperty(expected);
        // Assert
        actionResult.ShouldBeAssignableTo<OkResult>();
        _mediatorMock.Verify(x => x.Send(expected));
    }
