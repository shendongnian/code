    var mock = new Mock<IFoo>();
    var bar = mock.As<IBar>();
    mock.SetupGet(m => m.Blah).Returns("Blah");
    Assert.That(mock.Object.Blah, Is.EqualTo("Blah"));
    bar.SetupGet(m => m.Blah).Returns("BlahBlah");
    Assert.That(((IBar)mock.Object).Blah, Is.EqualTo("BlahBlah"));
    Assert.That(mock.Object.Blah, Is.EqualTo("Blah"));
