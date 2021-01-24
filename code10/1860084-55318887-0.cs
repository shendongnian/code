    var container = new UnityContainer();
    
    var mock = new Mock<IHeaderService>();
    mock.Setup(x => x.GetHeaderFromHttpRequest()).Returns("MockId");
    container.RegisterInstance(mock.Object);
