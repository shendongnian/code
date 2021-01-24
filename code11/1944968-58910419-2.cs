 [Test]
 [Author("Author_Name")]
 public void TestTest() { /* ... */ }
}
and retrieve using below in TearDown method
var category = (string) TestContext.CurrentContext.Test.Properties.Get("Author");
If you are using TestCaseSource attribute then use the below to set the Author property in Test method
        [Test]        
        [TestCaseSource(typeof(TestDataMerlin), "LoginDetails", new object[] { new string[] { "TC01"} })]
        public void PatientEnrollment(string userDetails, LoginDetails loginDetails)
        {                      
        TestExecutionContext.CurrentContext.CurrentTest.Properties.Add("Author", "Author_Name");
        }
        [TearDown]
        public void TestCleanup()
        {
            string name = TestExecutionContext.CurrentContext.CurrentTest.Properties.Get("Author").ToString();
        }
