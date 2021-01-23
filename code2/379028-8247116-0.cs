    [TestFixtureSetUp]
    public void TestFixtureSetUp()
    {
        
        //this grabs the data from the database using an XSD file to map the schema
        //and saves it as xml (backup.xml)
        DatabaseFixtureSetUp();  
    }
    [SetUp]
    public void SetUp()
    {
        
        //this inserts test data into the database from xml (testdata.xml)
        //it clears the tables first so you have fresh data before every test. 
        DatabaseSetUp();  
    }
    [TestFixtureTearDown]
    public void TestFixtureTearDown()
    {
         //this clears the table and inserts the backup data into the database
         //to return it to the state it was before running the tests.
        DatabaseFixtureTearDown();
    }
 
