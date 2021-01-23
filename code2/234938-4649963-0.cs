    public ICalculatorService
    {
      int Add(int a, int b);
    }
    [Test]
    public void CannAdd()
    {
      var mock = Mock<ICalculatorService();
      mock.Setup(m => m.Add(It.IsAny<int>(), It.IsAny<int>()))
          .Returns(100);
          
      var service = mock.Object;
      Assert(service.Add(1, 2) == 100); // Incorrect
    }
