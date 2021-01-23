    var mock = new Mock<IRepository>();
    var mockStore = new Mock<Store>();
    mock.Setup(x => x.GetById<Store>(It.IsAny<int>())).Returns(mockStore.Object);
    mockStore.SetupGet(s => s.Id).Returns(5);
    mockStore.SetupGet(s => s.Value).Returns("Walmart");
    var store = Repository.GetById<Store>(5);
    Assert.That(store.Id == 5);
