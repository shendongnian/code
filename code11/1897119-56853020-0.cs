    [TestClass]
    public class MyTestClass {
        [TestMethod]
        public void NSubstitute_Mocking_ReadOnly_Properties_Works() {
            //Arrange
            var expected = "http://localhost";
            var _appConfig = Substitute.For<IAppConfig>();
            _appConfig.BaseURL.Returns(expected);
            var subject = new PeopleService(_appConfig);
            //Act
            var actual = subject.URL;
            //Assert
            actual.Should().Be(expected);
        }
    }
    class PeopleService {
        IAppConfig _appConfig;
        public PeopleService(IAppConfig appConfig) {
            _appConfig = appConfig;
        }
        public string URL => _appConfig.BaseURL;
    }
    public interface IAppConfig {
        string BaseURL { get; }
        string AnotherProperty { get; }
    }
