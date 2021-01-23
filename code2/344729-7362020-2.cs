    [TestMethod]
    public void MyTest()
    {
        Parameter parameter = CreateParameter();
        parameter.someInt = 23;
        SomeClass.MethodBeingTested(parameter);
    }
