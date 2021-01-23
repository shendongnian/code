    public partial class MyModelUnitOfWork : ObjectContext
    {
    	public const string ContainerName = "MyModelUnitOfWork";
        public static readonly string ConnectionString
    		= ConnectionManager.GetConnectionString("MyModel");
