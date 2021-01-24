    public interface IMyKeyVaultClient {
       Task<string> GetSecretAsync(string secretName);
    }
    
    public class MyKeyVaultClient : IMyKeyVaultClient {
       public MyKeyVaultClient(IConfiguration config, IWhateverElseYouNeedForGettingCredentials otherStuff) {
           //snag the URL from config and credentials from otherStuff
           //instantiate keyVaultClient;
       }
       private KeyVaultClient keyVaultClient;
       private string url;
       public Task<string> GetSecretAsync(string secretName) {
           return keyVaultClient.GetSecretAsync(url, secretName);
       }
    }
