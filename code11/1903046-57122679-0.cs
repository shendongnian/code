    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    namespace TestProject
    {
        [TestClass]
        public class UnitTest
        {
            [MyTestMethod]
            public void TestMethod()
            {
                Assert.IsTrue(false);
            }
        }
    
        public class MyTestMethodAttribute : TestMethodAttribute
        {
            public override TestResult[] Execute(ITestMethod testMethod)
            {
                TestResult[] results = base.Execute(testMethod);
    
                foreach (TestResult result in results)
                {
                    if (result.Outcome == UnitTestOutcome.Failed)
                    {
                        string message = result.TestFailureException.Message;
                    }
                }
    
                return results;
            }
        }
    }
