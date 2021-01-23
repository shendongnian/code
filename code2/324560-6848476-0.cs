    class Logger_IOC_Tests
    {
        [Test] 
        public void Logger_should_be_initialized_with_the_type_of_the_object_that_is_using_it()
        {
            var container = new UnityContainer();
            container.AddNewExtension<LoggingExtension>();
            container.RegisterType<LoggerUser>(new ContainerControlledLifetimeManager());
            var user = container.Resolve<LoggerUser>();
            
            Assert.True(user.Logger.GetUserType() == user.GetType());
        }
    }
    
    class LoggingExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Context.Policies.SetDefault(typeof(IConstructorSelectorPolicy), new LoggingConstructorSelectorPolicy()); 
        }
    }
    public class LoggingConstructorSelectorPolicy : DefaultUnityConstructorSelectorPolicy
    {
        protected override IDependencyResolverPolicy CreateResolver(ParameterInfo parameter)
        {
            return parameter.ParameterType == typeof(ILogger) 
                       ? new LoggerResolverPolicy(parameter.Member.DeclaringType) 
                       : base.CreateResolver(parameter);
        }
    }
    class LoggerResolverPolicy : IDependencyResolverPolicy
    {
        private readonly Type _dependantType;
        public LoggerResolverPolicy(Type dependantType)
        {
            _dependantType = dependantType;
        }
        public object Resolve(IBuilderContext context)
        {
            return new Logger(_dependantType);
        }
    }
