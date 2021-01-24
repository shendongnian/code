public void ConfigureServices(IServiceCollection services)
{
    services.AddRazorPages();
    
    var connString=Configuration.GetConnectionString("SchoolContext");  
    var useSqlServer=Configuration.GetSection("MyDbConfig").GetValue<bool>("UseSqlServer");
    services.AddDbContext<SchoolContext>(options =>{
        if (useSqlServer)
        {
            options.UseSqlServer(connString);
        }
        else 
        {
            options.UseNpgsql(connString);
        }
    });
}
or 
var provider=Configuration.GetSection("MyDbConfig").GetValue<ProviderEnum>("Provider");
services.AddDbContext<SchoolContext>(options =>{
    switch (provider)
    {
        case ProviderEnum.SqlServer:
             options.UseSqlServer(connString);
             break;
        case ProviderEnum.Postgres :
             options.UseNpgsql(connString);
             break;
        ...
    }
});
That flag can come from configuration as well, eg from the command-line, environment variables, etc. 
**Refactoring to .... lots**
*Builder picker*
The builder, configuration patterns allow many variations that can handle complex scenarios. For example, we can pick a builder method in advance  :
    var efBuilder= SelectBuilder(provider,connString);
    services.AddDbContext<SchoolContext>(efBuilder);
    ...
    Action<DbContextOptionsBuilder> SelectBuilder(ProviderEnum provider,string connString)
    {
        switch (provider)
        {
            case ProviderEnum.SqlServer:
               return ConfigureSql;
            case ProviderEnum.Postgres :
               return ConfigurePostgres;
        }
        void ConfigureSqlServer(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(connString);
        }
        void ConfigurePostgres(DbContextOptionsBuilder options)
        {
            options.UseNpgSql(connString);
        }
    }
In C# 8 this could be reduced to: 
    Action<DbContextOptionsBuilder> SelectBuilder(ProviderEnum provider,string connString)
    {
        return provider switch (provider) {
            ProviderEnum.SqlServer => ConfigureSql,
            ProviderEnum.Postgres => ConfigurePostgres
        };
        void ConfigureSqlServer(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(connString);
        }
        void ConfigurePostgres(DbContextOptionsBuilder options)
        {
            options.UseNpgSql(connString);
        }
    }
*Concrete config class*
Another possibility is to create a strongly-typed configuration class and have *it* provide the builder :
class MyDbConfig
{
    public ProviderEnum Provider {get;set;}
    ....
    public Action<DbContextOptionsBuilder> SelectBuilder(string connString)
    {
        return provider switch (provider) {
            ProviderEnum.SqlServer => ConfigureSql,
            ProviderEnum.Postgres => ConfigurePostgres
        };
        void ConfigureSqlServer(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(connString);
        }
        void ConfigurePostgres(DbContextOptionsBuilder options)
        {
            options.UseNpgSql(connString);
        }
    }
}
and use it :
var dbConfig=Configuration.Get<MyDbConfig>("MyDbConfig");
var efBuilder=dbCongig.SelectBuilder(connString);
services.AddDbContext<SchoolContext>(efBuilder);
