    [TestClass]
    public class RunMbUnitTests
    {
    	[TestMethod]
    	public void RunAllTests()
    	{
    		var fixture = new YourMbUnitFixture();
    		foreach (var method in GetTestMethods(fixture))
    		{
    			method.Invoke(fixture);
    		}
    	}
    	
    	private IEnumerable<MethodInfo> GetTestMethods(object mbUnitFixture)
    	{
    		//reflection code to return all test methods from the MbUnit fixture
    	}
    }
