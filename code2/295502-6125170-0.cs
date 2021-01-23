    [Test]
    public void MakeItGoBang()
    {
         Foo foo = new Foo();
         try
         {
             foo.Bang();
             Assert.Fail("Expected exception");
         }
         catch (BangException)
         { 
             // Expected
         }
    }
