    internal class DynamicHttpClientFactoryConfiguration : IConfigureNamedOptions<HttpClientFactoryOptions>
	{
		public void Configure(String httpClientName, HttpClientFactoryOptions options)
		{
			if (httpClientName == nameof(OntraportHttpClient))
			{
				options.HttpMessageHandlerBuilderActions.Add(httpMessageHandlerBuilder =>
				{
					httpMessageHandlerBuilder.AdditionalHandlers.Add(pollyDelegatingHandler);
				});
			}
		}
	} 
