[Test]
public void SpotifyClientInformation_ReturnsExpectedClientIdAndSecretIdTuple()
{
    var logger = Mock.Of<ILogger<Helper>>();
    var expectedClientId = "My client Id";
    var expectedSecretId = "My secret Id";
    var configurationMock = new Mock<IConfiguration>();
    configurationMock.Setup(m => m["SpotifySecrets:clientID"]).Returns(expectedClientId);
    configurationMock.Setup(m => m["SpotifySecrets:secretID"]).Returns(expectedSecretId);
    var configuration = configurationMock.Object;
    var helper = new Helper(configuration, logger);
    var (actualClientId, actualSecretId) = helper.SpotifyClientInformation();
    Assert.Multiple(() =>
    {
        Assert.That(actualClientId, Is.EqualTo(expectedClientId));
        Assert.That(actualSecretId, Is.EqualTo(expectedSecretId));
    });
}
**Arrange** the dependencies and set up the test state; **Act** by invoking SpotifyClientInformation; and finally **Assert** that the resulting tuple has the expected values.
Following on from there you can easily increase your coverage for the null configuration case
[Test]
public void SpotifyClientInformation_WithNullConfiguration_ReturnsNull()
{
    var logger = Mock.Of<ILogger<Helper>>();
    var helper = new Helper(null, logger);
    var actualResult = helper.SpotifyClientInformation();
    Assert.That(actualResult, Is.Null);
}
It is possible to assert the log message with another test but I don't believe it's realistic. All you're doing is reading values from the configuration instance and creating the tuple and I don't think either will produce an exception. Attempting to read a configuration key that doesn't exist returns null.
A better way **if you wanted to capture that scenario with a log message** would be to do it in the constructor
public class Helper : IHelpers
{
    private IConfiguration configuration;
    private readonly ILogger<Helper> logger;
    public Helper(IConfiguration _config, ILogger<Helper> _logger)
    {
        configuration = _config;
        logger = _logger;
        if (configuration == null)
        {
            logger.LogCritical("Configuration DI not set up correctly");
        }
    }
    public Tuple<string, string> SpotifyClientInformation()
    {
        if (configuration == null)
        {
            return null;
        }
        string clientID = configuration["SpotifySecrets:clientID"];
        //Todo move secretID to more secure location
        string secretID = configuration["SpotifySecrets:secretID"];
        return new Tuple<string, string>(clientID, secretID);
    }
}
Then if you want to assert the log message
[Test]
public void Initialize_NullConfiguration_GeneratesCriticalLog()
{
    var expectedLogMessage = "Configuration DI not set up correctly";
    var logger = Mock.Of<ILogger<Helper>>();
    var helper = new Helper(null, logger);
    
    Mock.Get(logger).Verify(m => m.Log(
            LogLevel.Critical,
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((o, t) => HasLogMessage(o, expectedLogMessage)),
            It.IsAny<KeyNotFoundException>(),
            (Func<It.IsAnyType, Exception, string>) It.IsAny<object>()),
        Times.Once
    );
}
private static bool HasLogMessage(object state, string expectedMessage)
{
    var loggedValues = (IReadOnlyList<KeyValuePair<string, object>>) state;
    var unformattedMessage = loggedValues[^1].Value.ToString();
    return unformattedMessage.Equals(expectedMessage, StringComparison.CurrentCultureIgnoreCase);
}
Personally I don't worry about null guarding DI staples like loggers and configuration. If I had to, I'd raise an ArgumentNullException to really ram it home that this class can't/shouldn't operate without it and I should fix the DI configuration before deploying. Doing that would mean you could do away with the null check in the `SpotifyClientInformation` method plus any null checking for blocks that consume `SpotifyClientInformation`.
