    //Let's inject configuration too
    //Defaults stolen from AzureServiceTokenProvider's source
    public class TokenConfig
    {
        public string ConnectionString {get;set;};    
        public string AzureAdInstance {get;set;} = "https://login.microsoftonline.com/";
        public string TennantId{get;set;}
        public string Resource {get;set;}
    }
    class DbContextWithAddProvider
    {
        readonly AzureServiceTokenProvider _provider;
        readonly TokenConfig _config;
        readonly IServiceProvider _svcProvider;
        public DbContextWithAddProvider(IServiceProvider svcProvider, IOption<TokenConfig> config)
        {
            _config=config;
            _provider=new AzureServiceTokenProvider(config.ConnectionString,config.AzureAdInstance);
            _svcProvider=svcProvider;
        }
        public async Task<T> GetContextAsync<T>() where T:DbContext
        {
            var token=await _provider.GetAccessTokenAsync(_config.Resource,_config.TennantId);
            var dbContext = _svcProvider.GetRequiredService<T>();  
            var connection = dbContext.Database.GetDbConnection() as System.Data.SqlClient.SqlConnection;
            connection.AccessToken = token;
            return dbContext;
        }
    }
