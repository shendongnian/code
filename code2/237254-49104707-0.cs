    [TestClass]
    public class TheTestedClassTest
    {
        [ContractTestCase]
        public void TheTestedMethod()
        {
            "When Xxx happens, results in Yyy.".Test(() =>
            {
                // Write test case code here...
            });
            
            "When Zzz happens, results in Www.".Test(() =>
            {
                // Write test case code here...
            });
        }
    }
