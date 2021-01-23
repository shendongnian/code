    // Somewhere in unit test project
    
    class SomeDataMock : ISomeData
    {
      // you should implement this method manually or use some mocking framework
      public IEnumerable<string> YourData { get; }
    }
    
    [TestCase]
    public void SomeTest()
    {
      ISomeData mock = new SomeDataMock();
      var yourClass = new YourClass(mock);
      // test your class without any dependency on concrete implementation
    }
