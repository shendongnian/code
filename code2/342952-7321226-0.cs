    Mock<I1> menuServiceMock = new Mock<I1>();
    var i2Mock = menuServiceMock.As<I2>();
    // Verifies that I2.Foo was called on the object
    i2Mock.Verify(x => x.Foo("foo"), Times.Once());
    // Verifies that I1.Foo was called on the object:
    menuServiceMock.Verify(x => x.Foo("foo"), Times.Once());
