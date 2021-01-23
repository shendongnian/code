    [TestCase(null,0)]
    [TestCase(0,0)]
    [TestCase(10,10)]
    [TestCase(-10,10)]
    public void TestItWorksForInput(int? input, int expectedOutput)
    {
       var myVar = new MyClass();
       var output = myVar.MyMethod(argument);
       Assert.That(output, Is.EqualTo(expectedOutput));
    }
