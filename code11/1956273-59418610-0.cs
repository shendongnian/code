    var test = "Test";
    
    var command = new MyCommand { V = test };
    
    var mock = new Mock<IRepository>(); // 
    IRepository has the method of Save()
    var p = new P(test);
    mock.Setup(x => x.Save(It.Is<P>(v => v.Value.Equals(p.Value)))).Verifiable();
    
    var sut = new C(mock.Object);
    var result = await sut.M(command);
    
    mock.Verify();
