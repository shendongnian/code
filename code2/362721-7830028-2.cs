    [TestCase(null,0)]
    [TestCase(0,0)]
    [TestCase(1, 1 /* absolute value */)]
    public void DivideTest(int? argument, int expectedResult)
    {
       // Arrange
       var myVar = new MyClass();
       // Act
       var result = myVar.MyMethod(argument) 
       // Assert
       Assert.That(result, Is.EqualTo(expectedResult));
    }
