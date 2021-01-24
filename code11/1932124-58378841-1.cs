    [TestClass]
    public class DataTests{
        [TestMethod]
        public void Should_Return_Customer() {
            //Arrange
            var readerMock = new Mock<IDataReader>();
            readerMock.SetupSequence(_ => _.Read())
                .Returns(true)
                .Returns(false);
            readerMock.Setup(reader => reader.GetOrdinal("Id")).Returns(1);
            readerMock.Setup(reader => reader.GetOrdinal("Name")).Returns(2);
            readerMock.Setup(reader => reader.GetInt32(It.IsAny<int>())).Returns(1);
            readerMock.Setup(reader => reader.GetString(It.IsAny<int>())).Returns("Hello World");
            var commandMock = new Mock<IDbCommand>();            
            commandMock.Setup(m => m.ExecuteReader()).Returns(readerMock.Object).Verifiable();
                      
            var connectionMock = new Mock<IDbConnection>();
            connectionMock.Setup(m => m.CreateCommand()).Returns(commandMock.Object);
            var data = new Data(() => connectionMock.Object);
            //Act
            var result = data.FindAll();
            //Assert - FluentAssertions
            result.Should().HaveCount(1);
            commandMock.Verify(); //since it was marked verifiable.
        }
    }
