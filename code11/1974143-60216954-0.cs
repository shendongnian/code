	public static void Main(string[] args)
    {
        CreateWebHostBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
			    if (env.IsLocal())
                {
					...
                }
                else
                {
                    config.AddAzureKeyVault(keyVaultUri);
                }
            })
            .Build()
            .Run();
	}
