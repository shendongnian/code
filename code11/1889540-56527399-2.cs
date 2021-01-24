    [TestClass]
    public class MainClassTests {    
        [TestMethod]
        public void Should_AddDetails_To_Database() {
            // Arrange
            var mockDb = new Mock<IDatabase>();
            var data = new Data();
            var mainClass = new MainClass(Mock.Of<ILogger>(), mockDb.Object);
                
            // Act
            mainClass.AddDetails(data);
    
            // Assert    
            mockDb.Verify(_ => _.Add(data), Times.Once);
        }
    }
