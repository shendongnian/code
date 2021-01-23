    [TestCleanup()]
        public void MyTestCleanup()
        {
            string nomfichiersource = "UITestActionLog.html";
            string nomTest = TestContext.TestName.ToString();
            string sourcefile = System.IO.Path.Combine(TestContext.TestResultsDirectory, nomfichiersource);
            string destfile = System.IO.Path.Combine(@"X:\Temp", nomTest + ".html");
            System.IO.File.Copy(sourcefile, destfile);
        }
