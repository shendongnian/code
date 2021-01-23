        [TestClass]
        public class UnitTest1
        {
            Parameter _parameter = null;
    
            [TestInitialize]
            public void Initialize()
            {
                _parameter = new Parameter
                {
                    someInt = 42,
                    someDecimal = 42.42m,
                    subParameter = new SubParameter { someString = "42" }
                };
            }
    
            [TestCleanup]
            public void Cleanup()
            {
                _parameter = null;
            }
    
            [TestMethod]
            public void MyTest1()
            {
               // test _parameter
            }
    
            [TestMethod]
            public void MyTest2()
            {
               // test _parameter
            }
        }
