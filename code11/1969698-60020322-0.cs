        private HttpClient GetHttpClient()
        {
            return _factory.CreateClient();
        }
to
        protected HttpClient GetHttpClient()
        {
            var opts = new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            };
            return _factory.CreateClient(opts);
        }
