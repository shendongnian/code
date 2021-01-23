    //app.config
    <connectionStrings>
    	<add name="TestEntities" connectionString="...." />
    </connectionStrings>
    
    //data entities
    public partial class TestEntities : ObjectContext
    {
    	public TestEntities() : base("name=TestEntities", "TestEntities")
    	{
    		...
    	}
    	....
    }
    	
    //factory in Data Access layer
    public sealed class TestEntitiesFactory
    {
    	public static Func<TestEntities> GetNewTestEntitiesInstance { get; set; }
    	
    	static TestEntitiesFactory()
    	{
    		GetNewTestEntitiesInstance = TestEntitiesCreator.CreateTestEntities;
    	}
    }
    	
    public sealed class TestEntitiesDefaultCreator
    {
    	public static TestEntities CreateTestEntities()
    	{
    		TestEntities test = new TestEntities();
    		
    		//whatever initializations you need
    		
    		return test;
    	}
    }
    
    //business layer
    using (TestEntities ctx = TestEntitiesFactory.GetNewTestEntitiesInstance())
    {
    
    }
