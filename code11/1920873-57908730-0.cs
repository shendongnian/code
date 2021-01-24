    [TestFixture]
    public class MyHostedServiceTests {
        [SetUp]
        public void SetUp() {
            this.myService = new Mock<IMyService>();
    
            this.hostedService = new MyHostedService(this.myService.Object, new Setting { Frequency = 2 });
        }
    
        private Mock<ImyService> myService;
        private MyHostedService hostedService;
    
        [Test]
        public async Task StartAsync_Success() {
            
            //Act
            await this.hostedService.StartAsync(CancellationToken.None);
            await Task.Delay(TimeSpan.FromSeconds(1));    
            await this.hostedService.StopAsync(CancellationToken.None);
            //Assert
            this.myService.Verify(x => x.DoStuff(), Times.Once);
        }
    }
