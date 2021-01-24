    [TestClass]
    public class SocketManagerTests {
        [TestMethod]
        public void ConnectTest() {
            //Arrange
            var mockSocket = new Mock<ISocket>();
            //async result needed for callback
            IAsyncResult result = Mock.Of<IAsyncResult>();
            //set mock
            mockSocket.Setup(_ => _.BeginConnect(
                    It.IsAny<EndPoint>(), It.IsAny<AsyncCallback>(), It.IsAny<object>())
                )
                .Returns((EndPoint ep, AsyncCallback cb, object state) => result)
                .Callback((EndPoint ep, AsyncCallback cb, object state) => {
                    var m = Mock.Get(result);
                    m.Setup(_ => _.AsyncState).Returns(state);
                    cb(result);
                });
            var manager = new SocketManager(mockSocket.Object);
            //Act
            var actual = manager.Connect();
            //Assert
            Assert.IsTrue(actual);
            mockSocket.Verify(_ => _.EndConnect(result), Times.Once);
        }
    }
