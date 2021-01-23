    int Add(object a, object b)
    {
       return a+b;
    }
    
    [TestMethod]
    void AddFailsWithNonIntegerArguments()
    {
        try
        {
          Add("Hello", "World");
          Assert::Fail();
        }
        catch
        {
          Assert::Pass();
        }
    }
