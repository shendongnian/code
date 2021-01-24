    using System;
    using Microsoft.Azure.KeyVault;
    using Microsoft.Azure.Services.AppAuthentication;
    
    namespace test1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var azureServiceTokenProvider1 = new AzureServiceTokenProvider();
                var kv = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider1.KeyVaultTokenCallback));
                var secret = kv.GetSecretAsync("https://keyvaultname.vault.azure.net/", "test2").GetAwaiter().GetResult();
                Console.WriteLine(secret);
                
            }
        }
    }
