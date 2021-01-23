    var mock = new Mock<IComparable<string>>();
    mock.Setup(x => x.CompareTo("a")).Returns(1).Verifiable();
    mock.Setup(x => x.CompareTo("z")).Returns(-1).Verifiable();
    Assert.IsTrue(mock.Object.Between("a", "z"));
    mock.Verify();
