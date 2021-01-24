    [TestClass]
    public class WorkerTests {
        [TestMethod]
        public async Task Sohuld_Cancel_Run() {
            //Arrange
            int expectedCount = 5;
            int count = 0;
            CancellationTokenSource cts = new CancellationTokenSource();
            var mock = new Mock<IDependency>();
            mock.Setup(_ => _.DoSomething())
                .Callback(() => {
                    count++;
                    if (count == expectedCount)
                        cts.Cancel();
                })
                .Returns(() => Task.FromResult<object>(null));
            var worker = new Worker(mock.Object);
            //Act
            await worker.Run(cts.Token);
            //Assert
            mock.Verify(_ => _.DoSomething(), Times.Exactly(expectedCount));
        }
    }
