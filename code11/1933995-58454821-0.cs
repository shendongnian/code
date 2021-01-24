    //Arrange
    var itemChildMock = new Mock<IItemChildExtension>();
    itemChildMock.As<IItemChild>().Setup(mock => mock.PerformAction(1, 0, 1)).Callback(() => {
        var test = 2;
    });
    var itemExtension = new ItemExtension(itemChildMock.Object);
    //itemExtension = new ItemExtension(new ItemChildExtension());
    //Act
    itemExtension.PerformAction();
    var invocations = itemChildMock.Invocations;
