    var test = "Test";
    var mock = new Mock<ITestRepository>(); // ITestRepository has the method of Save()
    var p = new P(test);
    mock.Setup(x => x.Save(It.IsAny<P>()));
    mock.Object.Save(new P(test));
    mock.Verify(x => x.Save(It.Is<P>(v => v.Value.Equals(p.Value))), Times.AtLeastOnce);
 
