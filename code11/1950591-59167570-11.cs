    [TestClass]
    public class SomeServiceHostTests {
        [TestMethod]
        public void Should_Start_Services() {
            //Arrange
            var service = new Mock<IService>();
            var repository = Mock.Of<IServiceRepository>(_ => _.Get() == new[] { service.Object });
            var subject = new SomeServiceHost(repository);
            ServiceStatus before = subject.Status;
            ServiceStatus during = default(ServiceStatus);
            service.Setup(_ => _.Start()).Callback(() => during = subject.Status);
            //Act
            subject.Start();
            ServiceStatus after = subject.Status;
            //Assert
            before.Should().Be(ServiceStatus.Stopped);
            during.Should().Be(ServiceStatus.Starting);
            after.Should().Be(ServiceStatus.Running);
            service.Verify(_ => _.Start());//invoked at least once;
        }
    }
