    /// <summary> 
    /// HTTP client initializer for changing the default behavior of HTTP client. 
    /// Use this initializer to change default values like timeout and number of tries. 
    /// You can also set different handlers and interceptors like 
    /// <see cref="IHttpUnsuccessfulResponseHandler"/>s, 
    /// <see cref="IHttpExceptionHandler"/>s and <see cref="IHttpExecuteInterceptor"/>s.
    /// </summary>
    public interface IConfigurableHttpClientInitializer
    {
        /// <summary>Initializes a HTTP client after it was created.</summary>
        void Initialize(ConfigurableHttpClient httpClient);
    }
