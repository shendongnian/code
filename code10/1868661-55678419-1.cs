       var server = new Grpc.Core.Server
                {
                    Services =
                    {
                        
    TestService.BindService(new TestImplementationService()).Intercept(IoC.Resolve<GlobalServerLoggerInterceptor>())
                    },
                    Ports = { new ServerPort("localhost", 1234, ServerCredentials.Insecure) }
                };
