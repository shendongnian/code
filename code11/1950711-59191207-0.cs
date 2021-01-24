    [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"C:\Users\Administrator\source\repos\UnitTestProject2\UnitTestProject2\data.csv", "data#csv", DataAccessMethod.Sequential)]
            public void TestMethod1()
            {
                string va = TestContext.DataRow["Num1"].ToString();
                switch (va)
                {
                    case "1": TEST1(); break;
                    case "4": TEST2(); break;
                }
            }
    
            [TestMethod]
            public void TEST1()
            { 
                //Todo
             }
    
            [TestMethod]
            public void TEST2()
            {
                //Todo
            }
    
            private TestContext testContextInstance;
            public TestContext TestContext
            {
                get { return testContextInstance; }
                set { testContextInstance = value; }
            }
        }
