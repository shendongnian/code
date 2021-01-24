<connectionStrings>
     <add name="MaintenanceDB" connectionString="" providerName="System.Data.SqLite" />
</connectionStrings>
    public class MaintenanceDB : DbContext
    {
        public MaintenanceDB() : base ("Name=MaintenanceDB")
And try the solutions below:
    var context = new MaintenanceDB();
    if (!context.Database.Exists())
    	context.Database.Create();
	
Or
    var context = new MaintenanceDB();
    context.Database.CreateIfNotExists();
Or create an initializer class as below:
    // public class ContentInitializer: DropCreateDatabaseAlways <MaintenanceDB>
    // public class ContentInitializer: CreateDatabaseIfNotExists <MaintenanceDB>
    public class ContentInitializer: DropCreateDatabaseIfModelChanges <MaintenanceDB>
And put this at the beginning of the application.
    Database.SetInitializer (new ContentInitializer ());
