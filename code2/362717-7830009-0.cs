    [TestCase(null,0)]
    [TestCase(0,0)]
    public void TestWorksForInput(int? input, int expectedOutput)
    {
       var myVar = new MyClass();
       var output = myVar.MyMethod(argument);
       Assert.That(output, Is.EqualTo(expectedOutput));
    }
