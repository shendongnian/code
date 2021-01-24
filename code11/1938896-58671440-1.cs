    [TestClass]
    public class TenancyLogFilterTests {
        [TestMethod]
        public void Should_Log_LogEvent() {
            //Arrange            
            string expectedId = Guid.NewGuid().ToString();
            LogLevel expectedLevel = LogLevel.Error;
            FilterResult expected = FilterResult.Log;
            var context = new DefaultHttpContext();
            context.Request.Headers.Add(CustomHeaders.TenantId, expectedId);
            var accessor = Mock.Of<IHttpContextAccessor>(_ => _.HttpContext == context);
            var level = new Dictionary<string, LogLevel> {
                { expectedId, expectedLevel }
            };
            var config = Mock.Of<ITenancyLoggingConfiguration>(_ => _.TenantMinLoggingLevel == level);
            var subject = new TestTenancyLogFilter(config, accessor);
            var info = new LogEventInfo { Level = expectedLevel };
            //Act
            FilterResult actual = subject.GetFilterResult(info);
            //Assert - FluentAssertions
            actual.Should().Be(expected);
        }
        class TestTenancyLogFilter : TenancyLogFilter {
            public TestTenancyLogFilter(ITenancyLoggingConfiguration loggingConfigurationConfig, IHttpContextAccessor httpContextAccessor)
                : base(loggingConfigurationConfig, httpContextAccessor) { }
            public FilterResult GetFilterResult(LogEventInfo logEvent) {
                return Check(logEvent);
            }
        }
    }
