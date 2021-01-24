    [TestClass]
    public class LogInUserByForm_IntegrartionTest {
        private LogInUserByFormRequest CreateRequest(string userName, string password) {
            LogInUserByFormRequest request = new LogInUserByFormRequest {
                UserName = userName,
                Password = password
            };
    
            return request;
        }
    
        IMediator BuildMediator() {
            //AutoFac
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();
    
            var mediatrOpenTypes = new[] {
                typeof(IRequestHandler<,>)
            };
    
            foreach (var mediatrOpenType in mediatrOpenTypes) {
                builder
                    .RegisterAssemblyTypes(typeof(LogInUserByFormRequest).GetTypeInfo().Assembly)
                    .AsClosedTypesOf(mediatrOpenType)
                    .AsImplementedInterfaces();
            }
            
            builder.Register<ServiceFactory>(ctx => {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });
    
            //...all other needed dependencies.
    
            //...
            
            var container = builder.Build();
            
            var mediator = container.Resolve<IMediator>();
            return mediator;
        }
    
        [TestMethod]
        [Description("")]
        public async Task UserName_ShouldHave_Max_30Characters_Exception() {
            try
            {
                //Arrange
                var request = CreateRequest("UserNameIsGreaterThanAllowed", "password");
                var mediator = BuildMediator();
                
                //Act
                var response = await mediator.Send(request);
                
                //Assert
                //...assert the expected values of response.
            }
            catch (System.Exception ex)
            {
    
                throw;
            }
        }
    }
