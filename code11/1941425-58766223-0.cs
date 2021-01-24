interface IDbProvider {
    bool AppliesTo(string providerName);
    DbContextOptions<T> LoadProvider<T>();
}
public class PostgresSqlProvider : IDbProvider {
 
    public bool AppliesTo(string providerName) {
        return providerName.Equals("Postgres");
    }
    public DbContextOptions<T> LoadProvider<T>() {
        //load provider.
    }
}
var providers = new [] {
    new PostgresSqlProvider()
};
var selectedDbProvider = ""; //Load from user input / config
var selectedProvider = providers.SingleOrDefault(x => x.AppliesTo(selectedDbProvider));
if(selectedProvider == null) {
    throw new NotSupportedException($"Database provider {selectedDbProvider} is not supported.");
}
var options = selectedProvider.LoadProvider<DbContext>();
