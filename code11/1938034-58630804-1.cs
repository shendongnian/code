Mock<ILogger> _logger; // declare it somewhere where your test can access it
[Fact]
public void TestLogErrorMessage()
{
	MyClass myClass = new MyClass(MockLoggerFactory().Object);
	var result = myClass.Mymethod("a")
	_logger.Verify();
}
private Mock<ILoggerFactory> MockLoggerFactory()
{
	_logger = new Mock<ILogger>();
	_logger.Setup(log => log.LogError(It.IsAny<string>())).Verifiable();
	Mock<ILoggerFactory> mockLoggerFactory = new Mock<ILoggerFactory>(MockBehavior.Default);
	mockLoggerFactory.Setup(x => x.CreateLogger(It.IsAny<string>()))
						   .Returns(_logger.Object);
	return mockLoggerFactory;
} 
The key thing to note is the call to `Verifiable()` after setting up the `ILogger` mock. You can read a bit more about `Verifiable()` in [this SO question](https://stackoverflow.com/q/980554/1344058). After your test ran, you can check whether the method was called by calling `.Verify()` on the mock.
Depending on your needs, you could set this up in the constructor of your test class (if you need it for all/most tests) or directly inside your test method. You could also return it alongside the `ILoggerFactory`. The point is to hold onto the logger so you can verify against it that the method was called.
For your specific case (trying to verify calls to `ILogger.LogError`) you must not mock `LogError`, but the underlying method [`ILogger.Log`](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger.log?view=dotnet-plat-ext-3.0#Microsoft_Extensions_Logging_ILogger_Log__1_Microsoft_Extensions_Logging_LogLevel_Microsoft_Extensions_Logging_EventId___0_System_Exception_System_Func___0_System_Exception_System_String__). That could look like this:
    var formatter = new Func<It.IsAnyType, Exception, string>((a, b) => "");
	m.Setup(x => x.Log<It.IsAnyType>(LogLevel.Error, 
                                     It.IsAny<EventId>(),
                                     It.IsAny<It.IsAnyType>(),
                                     It.IsAny<Exception>(), 
                                     formatter))
	  .Verifiable();
Another alternative would be to make a fake implementation of `ILogger` and return that from the `Mock<ILoggerFactory>`:
mockLoggerFactory.Setup(_ => _.CreateLogger(It.IsAny<string>())
                 .Returns(new FakeLogger());
public class FakeLogger : ILogger
{
	public static bool LogErrorCalled { get; set; }
	
	public IDisposable BeginScope<TState>(TState state)
	{
		throw new NotImplementedException();
	}
	public bool IsEnabled(LogLevel logLevel) => true;
	public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
	{
		if(logLevel == LogLevel.Error)
		{
			LogErrorCalled = true;
		}
	}
}
And then after your test you can check whether `FakeLogger.LogErrorCalled` is `true`. This is simplified for your specific test - you can get more elaborate than this of course.
