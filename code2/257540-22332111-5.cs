    [TestFixture]
    public class CmsPageRepositoryTests
    {
        private readonly MsSqlDatabaseTestsHelper _msSqlDatabaseTestsHelper = 
            new MsSqlDatabaseTestsHelper(ConnectionStringWithoutDatabase);
        private const string ConnectionStringWithoutDatabase = 
            @"server=.\SqlExpress;uid=sa;pwd=1;";
        private const string DatabaseName = "TestPersistence";
        [SetUp]
        public void SetUp()
        {
            _msSqlDatabaseTestsHelper.DropDatabase(DatabaseName);
            _msSqlDatabaseTestsHelper.CreateDatabase(DatabaseName);
        }
        [TearDown]
        public void TearDown()
        {
            _msSqlDatabaseTestsHelper.DropDatabase(DatabaseName);
        }
        [Test]
        public void TestSomethingWithDatabaseUsing()
        {
        }
    }
