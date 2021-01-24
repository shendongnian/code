    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    
    namespace UnitTestProject
    {
        [TestClass]
        public class UnitTest
        {
            [ClassCleanup]
            public static void ClassCleanUp()
            {
                // Save TestResultCollection.Results in csv file
            }
    
            [MyTestMethod]
            public void TestMethod()
            {
                Assert.IsTrue(true);
            }
        }
    
        public static class TestResultCollection
        {
            public static Dictionary<ITestMethod, TestResult[]> Results { get; set; } = new Dictionary<ITestMethod, TestResult[]>();
        }
    
        public class MyTestMethodAttribute : TestMethodAttribute
        {
            public override TestResult[] Execute(ITestMethod testMethod)
            {
                TestResult[] results = base.Execute(testMethod);
    
                TestResultCollection.Results.Add(testMethod, results);
    
                return results;
            }
        }
    }
