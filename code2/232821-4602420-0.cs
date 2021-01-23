    [TearDown]
    public void CleanUp()
    {
        TestContext.CurrentContext.Test.FullName; //!=null
        someClassInstance.DoTearDown();
    }
    
    class SomeClass
    {
         public void DoTearDown()
         {
              TestContext.CurrentContext.Test.FullName; //==null
         }
    }
