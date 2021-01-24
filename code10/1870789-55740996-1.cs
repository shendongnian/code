         private async Task StartUpApplicationAsync()
         {
            await UserConfigurationManager.GetIfNeedsAsync();
          }
        private static void ConfigureFlurlHttp()
          {
            FlurlHttp.Configure(c =>
             {
                c.HttpClientFactory = new ModernHttpClientFactory();
             });
          }
