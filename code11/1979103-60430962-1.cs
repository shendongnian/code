    public void TestSomething()
    {
         var expectedValue1 = "SomeExpectedValue";
    
         TestableObject subject = instance.Method();
    
         Assert.Equal(expectedValue1, subject.Somevalue);
    }
