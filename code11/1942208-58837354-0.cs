    public class HttpClientModule<TService> : Module
    {
        public HttpClientModule(Action<HttpClient> clientConfigurator)
        {
            this._clientConfigurator = clientConfigurator;
        }
        private readonly Action<HttpClient> _clientConfigurator;
        protected override void AttachToComponentRegistration(IComponentRegistry componentRegistry, IComponentRegistration registration)
        {
            base.AttachToComponentRegistration(componentRegistry, registration);
            if (registration.Activator.LimitType == typeof(TService))
            {
                registration.Preparing += (sender, e) =>
                {
                    e.Parameters = e.Parameters.Union(
                      new[]
                      {
                        new ResolvedParameter(
                            (p, i) => p.ParameterType == typeof(HttpClient),
                            (p, i) => {
                                HttpClient client = i.Resolve<IHttpClientFactory>().CreateClient();
                                this._clientConfigurator(client);
                                return client;
                            }
                        )
                      });
                };
            }
        }
    }
