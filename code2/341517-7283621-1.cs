    int i = 0;
    var itemMock = new Mock<Item>();
    itemMock.Setup(i => i.Increment()).Callback(() => i++);
    var repositoryMock = new Moc<ItemRepository>();
    repositoryMock.Setup(r => r.Get(It.IsAny<int>()).Returns(itemMock.Object);
    Assert.AreEqual(i, 1);
