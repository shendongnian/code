    using Microsoft.Azure.Services.AppAuthentication;
    using Microsoft.Azure.KeyVault;
    using Microsoft.Extensions.Configuration.AzureKeyVault;
        
    ...
         
	public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
		WebHost.CreateDefaultBuilder(args)
			.ConfigureAppConfiguration((context, config) =>
			{
				if (context.HostingEnvironment.IsProduction())
				{
					var builtConfig = config.Build();
					var azureServiceTokenProvider = new AzureServiceTokenProvider();
					var keyVaultClient = new KeyVaultClient(
						new KeyVaultClient.AuthenticationCallback(
							azureServiceTokenProvider.KeyVaultTokenCallback));
					config.AddAzureKeyVault(
						$"https://{builtConfig["KeyVaultName"]}.vault.azure.net/",
						keyVaultClient,
						new DefaultKeyVaultSecretManager());
				}
			})
			.UseStartup<Startup>();
