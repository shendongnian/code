    string propA = null;
    
    var mock = new Mock<IMyObject>();
    mock.SetupSet(m => m.PropA = It.IsAny<string>())
        .Callback<string>(s => propA = s);
    mock.Setup(m => m.Id)
        .Returns(() => (propA?.GetHashCode()).GetValueOrDefault());
    
    mock.Object.PropA = "test";
    
    Assert.Equal("test".GetHashCode(), mock.Object.Id);
    
    mock.Object.PropA = "test 2";
    
    Assert.Equal("test 2".GetHashCode(), mock.Object.Id);
