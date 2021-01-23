    [TestCase(null,0)]
    [TestCase(0,0)]
    [TestCase(1, 1 /* absolute value */)]
    [TestCase(-1, 1)]
    public void MyMethod_should_return_absolute_value(int? argument, int expectedResult)
    {
       // Arrange
       var myVar = new MyClass();
       // Act
       var result = myVar.MyMethod(argument) 
       // Assert
       Assert.That(result, Is.EqualTo(expectedResult));
    }
