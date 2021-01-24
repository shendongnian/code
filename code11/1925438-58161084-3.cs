    [TestClass]
    public class GenericWebServiceTests {
        [TestMethod]
        public void Should_Create_New_WebService() {
            //Arrange
            var serviceFactory = Mock.Of<IWebServiceFactory>();
            var clientFactory = Mock.Of<IClientFactory>();
            //Act
            var actual = new WebService<WebServiceWRGClient, IWebService, User1>(serviceFactory, clientFactory);
            //Assert
            actual.Should().NotBeNull();
        }
        [TestMethod]
        public async Task Should_ClaimSearchAsync() {
            //Arrange
            var service = Mock.Of<IWebService>();
            Mock.Get(service)
                .Setup(_ => _.EncryptValueAsync(It.IsAny<string>()))
                .ReturnsAsync((string s) => s);
            var serviceFactory = Mock.Of<IWebServiceFactory>();
            Mock.Get(serviceFactory)
                .Setup(_ => _.Create<IWebService>(It.IsAny<string>()))
                .Returns(service);
            var clientFactory = Mock.Of<IClientFactory>();
            Mock.Get(clientFactory)
                .Setup(_ => _.Create<WebServiceWRGClient>())
                .Returns(() => new WebServiceWRGClient());
            string url = "url";
            string username = "username";
            string password = "password";
            var options = new WebServiceOptions {
                URL = url,
                UserName = username,
                Password = password
            };
            var webService = new WebService<WebServiceWRGClient, IWebService, User1>(serviceFactory, clientFactory);
            //Act
            var actual = await webService.SearchClaimAsync<WebServiceResult>(options);
            //Assert
            //Mock.Get(serviceFactory).Verify(_ => _.Create<IService1>(url));
            //Mock.Get(service).Verify(_ => _.EncryptValue(username));
            //Mock.Get(service).Verify(_ => _.EncryptValue(password));
            //Mock.Get(clientFactory).Verify(_ => _.Create<Client1>());
            actual.Should().NotBeNull();
        }
        #region Support
        public class User1 {
            public string UserName { get; set; }
            public string Password { get; set; }
        }
        public class User2 {
            public string UserName { get; set; }
            public string Password { get; set; }
        }
        public class WebServiceWRGClient {
            public Task<WebServiceResult> ClaimSearchAsync(User1 user, string ssn, string lastname, int claimnumber, statuscode statuscode, string assignedto) {
                return Task.FromResult(new WebServiceResult());
            }
        }
        public enum statuscode {
            NotSet = 0,
        }
        public class Client2 { }
        public interface IWebService {
            Task<string> EncryptValueAsync(string value);
        }
        public interface IService2 {
            Task<string> EncryptValueAsync(string value);
        }
        public class Service1 : IWebService {
            public Task<string> EncryptValueAsync(string value) {
                return Task.FromResult(value);
            }
        }
        public class WebServiceResult {
        }
        #endregion
    }
    
    
