    [TestClass]
    public class SocketManagerTests {
        [TestMethod]
        public void ConnectTest() {
            //Arrange
            var mockSocket = new Mock<ISocket>();
            //async result needed for callback
            IAsyncResult mockedIAsyncResult = Mock.Of<IAsyncResult>();
            //set mock
            mockSocket.Setup(_ => _.BeginConnect(
                    It.IsAny<EndPoint>(), It.IsAny<AsyncCallback>(), It.IsAny<object>())
                )
                .Returns(mockedIAsyncResult)
                .Callback((EndPoint ep, AsyncCallback cb, object state) => {
                    var m = Mock.Get(mockedIAsyncResult);
                    //setup state object on mocked async result
                    m.Setup(_ => _.AsyncState).Returns(state);
                    //invoke provided async callback delegate
                    cb(mockedIAsyncResult);
                });
            var manager = new SocketManager(mockSocket.Object);
            //Act
            var actual = manager.Connect();
            //Assert
            Assert.IsTrue(actual);
            mockSocket.Verify(_ => _.EndConnect(mockedIAsyncResult), Times.Once);
        }
    }
