csharp
// Defining an extension method
public static void IsLogReceived(this IMock<ILogger<StockService>>logger, LogLevel level, int count = 1) =>
	logger.Verify(x =>
		x.Log(level,
			It.IsAny<EventId>(),
			It.IsAny<It.IsAnyType>(),
			It.IsAny<Exception>(),
			(Func<It.IsAnyType, Exception, string>)It.IsAny<object>()), 
		Times.Exactly(count));
// [...]
// and using the ext. method like that:
[Fact]
public void TestNSubstituteAgain()
{
    var loggerMock = new Mock<ILogger<StockService>>();
    var logger = loggerMock.Object;
    logger.LogCritical(new Exception(), "Hey lads!");
    loggerMock.IsLogReceived(LogLevel.Critical);
}
It's not that accurate but depending on what's going on in the method scope, that can get the job done.
That being said, I concede that the most precise way of achieving that would be to declare a wrapping type.
Resources that helped me a bit:
- https://github.com/nsubstitute/NSubstitute/issues/597
- https://github.com/aspnet/Extensions/issues/1319
