private static KeyVaultClient GetClient()
{
   AzureServiceTokenProvider azureServiceTokenProvider = new AzureServiceTokenProvider();
   KeyVaultClient keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
   return keyVaultClient;
}
public static async Task<string> GetSecret(string secretName)
{
   try
   {
       using var client = GetClient();
       return (await client.GetSecretAsync(keyVaultUrl, secretName)).Value;
   }
   catch (KeyVaultErrorException)
   {
      return null;
   }
   catch (Exception ex)
   {
      return null;
   }
}
