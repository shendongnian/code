    [CodedUITest]
        public class SomeCodedUITest1
        {    
                public TestContext TestContext
                {
                    get
                    {
                        return testContextInstance;
                    }
                    set
                    {
                        testContextInstance = value;
                    }
                }
                private TestContext testContextInstance;
        
            [TestCategory("DataFiles"),
                     DataSource ( .... )]
              public void SampleMethod()
                {
                    MyClass = new MyClass(TestContext);
                }
        }
