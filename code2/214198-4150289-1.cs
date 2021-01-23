    [TestClass()]
    public class FinalClauseTester 
    { 
        private TestContext testContextInstance;
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
     
        [TestMethod] 
        [DeploymentItem(@"Something right goes here.")] 
        [DataSource("Something else goes here", "row", somethingOtherSetupCrap)] 
        public void TestFinalClause() 
        {
    
            string[] allStrings = {"1", "2", "3"};
            int yesCount = 0;
            foreach(string s in allStrings)
            {
            try
            {
                //Error happens here
                throw new Exception();
            }
            catch(Exception ex)
            {
                //Handle exception
                break;
            }
            finally
            {
                //Clean up code
                yesCount++;
            }
            
            // And, at the end of this loop ...
            Debug.Assert(yesCount = 3); // Or something like this.
        }
    }
