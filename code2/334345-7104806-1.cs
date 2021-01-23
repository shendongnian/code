    public class SimpleCalculator
    {
        public int SumTwoNumbers(int number1, int number2)
        {
            return number1 + number2;
        }
    }
    [TestClass]
    public class TestClass
    {
        [TestMethod]
        public void Test_SimpleCalculator_SumTwoNumbers_CorrectValues()
        {
            // Arrange
            SimpleCalculator calc = new SimpleCalculator();
            
            // Act
            int result = calc.SumTwoNumbers(5, 2);
            // Assert
            Assert.AreEqual(7, result);
        }
    }
