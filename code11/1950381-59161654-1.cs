    [TestClass]
    public class SignalrHub1Tests {
        public interface IClientContract {
            void SetServer(string s);
        }
        [TestMethod]
        public void GetCallControlData_Should_SetServer() {
            //Arrange
            var contract = new Mock<IClientContract>();
            contract.Setup(_ => _.SetServer(It.IsAny<string>()));
            var mockClients = new Mock<IHubCallerConnectionContext<dynamic>>();
            mockClient.Setup(m => m.Caller).Returns(contract.Object);
            var hub = new SignalRHub1() {
                Clients = mockClients.Object
            };
            //Act
            hub.GetCallControlData();
            //Assert
            contract.Verify(_ => _.SetServer("Server"));
        }
    }
