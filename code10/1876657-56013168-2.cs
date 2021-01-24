    public class EmailQueueServiceTests {
        [Fact]
        public async Task Should_AddAsync() {
            // Arrange 
            var configuration = GetConfiguration();
            IAmazonSQS client = configuration.GetAWSOptions().CreateServiceClient<IAmazonSQS>();
            var subject = new EmailQueueService(configuration, Mock.Of<ILogger<EmailQueueService>>());
            // Act
            var result = await subject.AddAsync(ContactFormModelMock.GetNew());
            // Assert
            Assert.True(result);
        }
        static IConfiguration GetConfiguration() {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            return builder.Build();
        }
    }
    
