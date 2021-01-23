    public abstract class IntegrationTestBase
    {
        private TransactionScope scope;
        [TestInitialize]
        public void TestInitialize()
        {
            scope = new TransactionScope();
        }
    
        [TestCleanup]
        public void TestCleanup()
        {
            scope.Dispose();
        }
    }
