    [TestFixture]
    public class MyTestFixture()
    {
      private IEnumerable<object[]> TestData
      {
        get
        {
            yield return new object[] { "MyWord", "droWyM", null };
            yield return new object[] { null, null, typeof(ArgumentNullException) };
            yield return new object[] { "", "", null };
            yield return new object[] { "123", "321", null };
        }
     }
     [Test, Factory("TestData")]
     public void MyTestMethod(string input, string expectedResult, Type expectedException)
     {
        RunWithPossibleExpectedException(expectedException, () => 
        {
           // Test logic here... 
        });
     }
     private void RunWithPossibleExpectedException(Type expectedException, Action action)
     {
       if (expectedException == null)
         Assert.DoesNotThrow(action);
       else
         Assert.Throws(expectedException, action);
     }
