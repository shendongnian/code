    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(-2, 2, 0)]
    [InlineData(int.MinValue, -1, int.MaxValue)]
    public void Calculator_CanAddValidValues(int value1, int value2, int expected) {
      var calculator = new Calculator();
      var result = calculator.Add(value1, value2);
      Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    [InlineData(89, 89)]
    public void Calculator_InValidValuesThrowArgumentOutOfRangeException(int value1, int value2) {
      var calculator = new Calculator();
      Assert.Throws<ArgumentOutOfRangeException>(() => calculator.Add(value1, value2);
    }
    
    public class Calculator {
      public int Add(int value1, int value2) {
    
        if (value1 == value2) 
          throw new ArgumentOutOfRangeException();
    
        return value1 + value2;
    
      }
    }
