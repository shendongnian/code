services.AddSingleton<AzureServiceTokenProvider>(new AzureServiceTokenProvider());
services.AddDbContext<SqlDBContext>();
----------
In your **DbContext.cs** :
private AzureServiceTokenProvider azureServiceTokenProvider;
public SqlDBContext(DbContextOptions<SqlDBContext> options, AzureServiceTokenProvider azureServiceTokenProvider) : base(options)
{
	this.azureServiceTokenProvider = azureServiceTokenProvider;
}
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
	SqlConnection connection = new SqlConnection();
	connection.ConnectionString = "Data Source=tcp:jackdemo.database.windows.net,1433; Initial Catalog=jackdemo; "; 
	connection.AccessToken = azureServiceTokenProvider.GetAccessTokenAsync("https://database.windows.net/").Result;
	optionsBuilder.UseSqlServer(connection);
}
  [1]: https://i.stack.imgur.com/QWBY1.png
