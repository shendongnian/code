     builder.Register(c => new HttpContextWrapper(HttpContext.Current) as HttpContextBase)
                   .As<HttpContextBase>().InstancePerLifetimeScope();
                builder.Register(c => c.Resolve<HttpContextBase>().Request)
                   .As<HttpRequestBase>().InstancePerLifetimeScope();
                builder.Register(c => c.Resolve<HttpContextBase>().Response)
                   .As<HttpResponseBase>().InstancePerLifetimeScope();
                builder.Register(c => c.Resolve<HttpContextBase>().Server)
                   .As<HttpServerUtilityBase>().InstancePerLifetimeScope();
                builder.Register(c => c.Resolve<HttpContextBase>().Session)
                   .As<HttpSessionStateBase>().InstancePerLifetimeScope();
                builder.RegisterType<TokenProvider>().As<ITokenProvider>().InstancePerLifetimeScope();
                builder.RegisterType<TokenCredentials>().Keyed<ServiceClientCredentials>("credentials").InstancePerLifetimeScope();
                builder.RegisterType<WebApiClient>()
                       .As<IWebApiClient>()
                       .WithParameter("baseUri", new Uri(ConfigurationManager.AppSettings["WebApiBaseUrl"])
                       )
                       .WithParameter((pi, ctx) => pi.ParameterType == typeof(ServiceClientCredentials),
                   (pi, ctx) => ctx.ResolveKeyed<ServiceClientCredentials>(pi.Name))
               .InstancePerLifetimeScope();
