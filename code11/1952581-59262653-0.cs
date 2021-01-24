    [TestCleanup]
        public void LogResult()
        {
            
            var testOutcome = TestContext.CurrentTestOutcome;
            string testName = TestContext.TestName;
            string testdir = Path.Combine(TestContext.TestDir,"log.txt");
    
            string str = testName + ": " + testOutcome.ToString() + "\n";
    
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(testdir))
            {
                file.WriteLine(str);
                file.WriteLine("Basic Data");
            }
        }
    
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }
    
        private TestContext testContextInstance;
