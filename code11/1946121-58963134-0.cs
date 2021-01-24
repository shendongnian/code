        [TestClass]
        public class BasicAuthenticationTests
        {
            private readonly Mock<IOptionsMonitor<AuthenticationSchemeOptions>> _options;
            private readonly Mock<ILoggerFactory> _loggerFactory;
            private readonly Mock<UrlEncoder> _encoder;
            private readonly Mock<ISystemClock> _clock;
            private readonly Mock<IProvidePrincipal> _principalProvider;
            private readonly BasicAuthenticationHandler _handler;
    
            public BasicAuthenticationTests()
            {
                _options = new Mock<IOptionsMonitor<AuthenticationSchemeOptions>>();
    
                var logger = new Mock<ILogger<BasicAuthenticationHandler>>();
                _loggerFactory = new Mock<ILoggerFactory>();
                _loggerFactory.Setup(x => x.CreateLogger(It.IsAny<String>())).Returns(logger.Object);
    
                _encoder = new Mock<UrlEncoder>();
                _clock = new Mock<ISystemClock>();
                _principalProvider = new Mock<IProvidePrincipal>();
    
                _handler = new BasicAuthenticationHandler(_options.Object, _loggerFactory.Object, _encoder.Object, _clock.Object, _principalProvider.Object);
            }
