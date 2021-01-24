    internal class DynamicMessageHandlerBuilderFilter : IHttpMessageHandlerBuilderFilter
	{
        public Action<HttpMessageHandlerBuilder> Configure(Action<HttpMessageHandlerBuilder> next)
        {
            return (builder) =>
            {
                next(builder);
    			if (builder.Name == nameof(OntraportHttpClient))
    			{
    				builder.AdditionalHandlers.Add(pollyDelegatingHandler);
    			}
            };
        }
	} 
