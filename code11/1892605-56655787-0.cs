    public partial class MastersContext : BaseContext
	{
        public MastersContext(string connectionString)
            : base(connectionString, typeof(MastersContext), "Entities.Masters.MastersEF")
        {
        }
        
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<Materials> Materials { get; set; }
	}
	
	public class BaseContext : DbContext, IDbContext
    {
		public BaseContext(string connectionString, Type contextType, string connectionMetadata)
						: base(GetEntityConnectionString(connectionString,
														 contextType.GetTypeInfo().Assembly.GetName().Name,
														 connectionMetadata))
		{
			this.Initialise();
		}
	}
	
	public static string GetEntityConnectionString(string connectionString, string contextTypeName, string connectionMetadata)
	{
		string result = string.Empty;
		EntityConnectionStringBuilder entityConnectionStringBuilder = new EntityConnectionStringBuilder //(System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder)
		{
			Provider = "System.Data.SqlClient",
			ProviderConnectionString = connectionString,
			Metadata = string.Format("res://{0}/{1}.csdl|res://{0}/{1}.ssdl|res://{0}/{1}.msl", contextTypeName, connectionMetadata)
		};
		result = entityConnectionStringBuilder.ToString();
		return result;
	}
