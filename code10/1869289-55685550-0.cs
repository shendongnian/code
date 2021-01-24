    // ADLS connection 
                    var adlCreds = GetCreds_SPI_SecretKey(tenantId, ADL_TOKEN_AUDIENCE, serviceAppIDADLS, servicePrincipalSecretADLS);
                    var adlsClient = AdlsClient.CreateClient(adlsName, adlCreds);
 
    private static ServiceClientCredentials GetCreds_SPI_SecretKey(string tenant,Uri tokenAudience,string clientId,string secretKey)
            {
                SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());
                var serviceSettings = ActiveDirectoryServiceSettings.Azure;
                serviceSettings.TokenAudience = tokenAudience;
                var creds = ApplicationTokenProvider.LoginSilentAsync(tenant,clientId,secretKey,serviceSettings).GetAwaiter().GetResult();
                return creds;
            }
