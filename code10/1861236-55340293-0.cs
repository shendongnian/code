    var mocked = new Mock<IUrlHelper>();
    mocked.Setup(x => x.Page(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<object>(), It.IsAny<string>()))
                        .Returns("whatever_string");
        
    IUrlHelper helper = mocked.Object;
