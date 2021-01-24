    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    namespace TimeLogger.Tests
    {
    	[TestClass]
    	public class YourTestClass
    	{
    		private static TestContext Context;
    
    		[ClassInitialize]
    		public static void InitClass(TestContext testContext)
    		{
    			Context = testContext;
    		}
    
    		[TestMethod]
    		public void Test_1()
    		{
    			Assert.IsTrue(true);
    		}
    		[TestMethod]
    		public void Test_2()
    		{
    			Assert.IsTrue(true);
    		}
    	}
    }
