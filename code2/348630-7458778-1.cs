    using System.Data.Entity.Database;
    public class MyDbInitializer : CreateDatabaseIfNotExists<MyDbContext>
    {
    	protected override void Seed(MyDbContext context)
    	{
    		// create some sample data
    	}
    }
