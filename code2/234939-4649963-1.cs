    public class Calculator
    {
      private readonly ICalculatorService _service;
      public Calculator(ICalculatorService service)
      {
        _service = service;
      }
      
      public int Add(int a, int b)
      {
        return _service.Add(a, b);
      }
    }
    [Test]
    public void CannAdd()
    {
      var mock = Mock<ICalculatorService();
      mock.Setup(m => m.Add(It.IsAny<int>(), It.IsAny<int>()))
          .Returns(100);
          
      var calculator = new Calculator(mock.Object);
      Assert(calculator.Add(1, 2) == 100); // Correct
    }
