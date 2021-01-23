    public class TransactionalTestFixture
    {
        private TransactionScope TxScope;
        [SetUp]
        public void TransactionalTestFixtureSetUp()
        {
            TxScope = new TransactionScope(TransactionScopeOption.RequiresNew, 
                                           new TransactionOptions {IsolationLevel = IsolationLevel.Serializable});
        }
        [TearDown]
        public void TransactionalTestFixtureTearDown()
        {
            TxScope.Dispose();
        }
    }
