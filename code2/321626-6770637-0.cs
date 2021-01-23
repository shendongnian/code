    var dependency1 = new Mock<IDependency1>()
      .Setup(d => d.GetSomeList(It.IsAny<int>())
      .Returns(new List<int>(new [] { 1, 2, 3 });  
    var dependency2 = new Mock<IDependency2>()
      .Setup(d => d.DoSomeProcessing(It.IsAny<int>())
      .Returns(x => x * 2); // You can get the input value and use it to determine an output value
