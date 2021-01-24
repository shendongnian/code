        static void Main(string[] args)
        {
            var client = new SimpleServiceClient();
            client.OpenAsync().GetAwaiter().GetResult();
            client.DelayedResponseAsync(2000).GetAwaiter().GetResult();
            var channel = client.InnerChannel;
            var httpChannelFactory = client.InnerChannel.GetProperty<IChannelFactory>();
            var cacheField = httpChannelFactory.GetType().GetField("_httpClientCache", BindingFlags.NonPublic | BindingFlags.Instance);
            var httpClientCache = cacheField.GetValue(httpChannelFactory);
            var cacheDictionaryField = httpClientCache.GetType().GetField("_items", BindingFlags.NonPublic | BindingFlags.Instance);
            IDictionary cacheDictionary = (IDictionary)cacheDictionaryField.GetValue(httpClientCache);
            foreach(var cacheKey in cacheDictionary.Keys)
            {
                var cacheEntry = cacheDictionary[cacheKey];
                var valueField = cacheEntry.GetType().GetField("value", BindingFlags.NonPublic | BindingFlags.Instance);
                HttpClient httpClient = (HttpClient)valueField.GetValue(cacheEntry);
                FixHttpClient(httpClient);
            }
            client.DelayedResponseAsync(50000).GetAwaiter().GetResult();
            Console.WriteLine("Done");
            Console.ReadLine();
        }
        private static void FixHttpClient(HttpClient httpClient)
        {
            var handlerField = typeof(HttpMessageInvoker).GetField("_handler", BindingFlags.NonPublic | BindingFlags.Instance);
            DelegatingHandler delegatingHandler = (DelegatingHandler)handlerField.GetValue(httpClient); // Should be of type ServiceModelHttpMessageHandler
            WinHttpHandler winHttpHandler = (WinHttpHandler)delegatingHandler.InnerHandler;
            WinHttpHandler newHandler = new WinHttpHandler();
            newHandler.ServerCredentials = winHttpHandler.ServerCredentials;
            newHandler.CookieUsePolicy = winHttpHandler.CookieUsePolicy;
            newHandler.ClientCertificates.AddRange(winHttpHandler.ClientCertificates);
            newHandler.ServerCertificateValidationCallback = winHttpHandler.ServerCertificateValidationCallback;
            newHandler.Proxy = winHttpHandler.Proxy;
            newHandler.AutomaticDecompression = winHttpHandler.AutomaticDecompression;
            newHandler.PreAuthenticate = winHttpHandler.PreAuthenticate;
            newHandler.CookieContainer = winHttpHandler.CookieContainer;
            // Fix the timeouts
            newHandler.ReceiveHeadersTimeout = Timeout.InfiniteTimeSpan;
            newHandler.ReceiveDataTimeout = Timeout.InfiniteTimeSpan;
            newHandler.SendTimeout = Timeout.InfiniteTimeSpan;
            var servicemodelHttpHandlerInnerHandlerField = delegatingHandler.GetType().GetField("_innerHandler", BindingFlags.NonPublic | BindingFlags.Instance);
            servicemodelHttpHandlerInnerHandlerField.SetValue(delegatingHandler, newHandler);
            var delegatingHandlerInnerHandlerField = typeof(DelegatingHandler).GetField("_innerHandler", BindingFlags.NonPublic | BindingFlags.Instance);
            delegatingHandlerInnerHandlerField.SetValue(delegatingHandler, newHandler);
        }
So eaily, pass your `HttpClient` to 
Code directly copied from this [gist][2].
  [1]: https://gist.github.com/mconnew
  [2]: https://gist.github.com/mconnew/0af8e688cedc32669a8e44a53fcbaa4a
