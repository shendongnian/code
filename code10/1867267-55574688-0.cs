c#
private static ILogger<T> CreateLogger<T>(ILoggerFactory factory)
{
	return new Logger<T>(factory);
}
And the final code (without reflection caching etc):
c#
// Arrange
IUnityContainer container = new UnityContainer();
var logfactory = new LoggerFactory();
var provider = new Serilog.Extensions.Logging.SerilogLoggerProvider();
logfactory.AddProvider(provider);
container.RegisterType(typeof(Microsoft.Extensions.Logging.ILogger<>),
	new InjectionFactory((ctr, type, name) =>
	{
		var loggerType = type.GetGenericArguments()[0];
		var myType = this.GetType();
		var createLoggerMethod1 = myType.GetMethod(nameof(CreateLogger),BindingFlags.Static | BindingFlags.NonPublic);
		var createLoggerMethod = createLoggerMethod1.MakeGenericMethod(loggerType);
		var logger = createLoggerMethod.Invoke(this, new object[] {logfactory});
	
		return logger;
	}));
container.RegisterType<MyClass, MyClass>();
// Assert
container.Resolve<MyClass>();
