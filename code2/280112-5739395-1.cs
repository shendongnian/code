    Mock<Foo> mock = Mock<Foo>();
    mock.Setup(m => m.B()).Returns(5);
    int result = mock.Object.A(4);
 
    Assert.That(result, Is.EqualTo(9));
