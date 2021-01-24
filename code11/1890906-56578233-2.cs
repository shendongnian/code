    public class ContextWithAccessToken : MainDbContext 
    {
        public ContextWithAccessToken(DbContextOptions options) : base(options)
        {
            var connection = (SqlConnection)this.Database.GetDbConnection();
            connection.AccessToken = (new AzureServiceTokenProvider()).GetAccessTokenAsync("https://database.windows.net/").Result;
        }
    }
