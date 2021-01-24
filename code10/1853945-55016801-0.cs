    class MainClass
        {
            public static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");
    
                var builder = new ContainerBuilder();
    
                builder.RegisterType<MyService>().As<IMyService>().InstancePerLifetimeScope();
                builder.RegisterType<EDataSvc>().InstancePerLifetimeScope();
    
                var container = builder.Build();
    
                using (var scope = container.BeginLifetimeScope())
                {
                    var service = scope.Resolve<MyService>();
                    service.MakeRequestAsync("test");
                }
            }
        }
    
        public class EDataSvc
        {
            public void SendRequestAsync()
            {
                //TODO:Send request
            }
        }
    
        public class MyService : IMyService
        {
            private EDataSvc _eDataService;
    
            public void MakeRequestAsync(EDataSvc eDataSvc)
            {
                _eDataService = eDataSvc;
            }
    
            public void MakeRequestAsync(string parameter)
            {
                //TODO prepare your data or additional logic
    
                _eDataService.SendRequestAsync();
            }
        }
    
        public interface IMyService
        {
            void MakeRequestAsync(string parameter);
        }
