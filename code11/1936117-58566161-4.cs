    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            Mock<IInnerChannel> innerChannelMock = new Mock<IInnerChannel>();
            innerChannelMock.Setup(i => i.TheInnerChannelMethod()).Returns("This 
            is a test from mocked object.");
            Mock<InterfaceUt.IClientChannelWrapper> mockClientWrapper = new 
            Mock<IClientChannelWrapper>();
            mockClientWrapper.Setup(m => 
            m.GetTheInnerChannelMethod()).Returns(innerChannelMock.Object);
    
            //Act
            ClassUsingChannelWrapper sut = new 
            ClassUsingChannelWrapper(mockClientWrapper.Object);
            sut.TheClientChannelConsumerMethod();
    
            //Assert
            innerChannelMock.Verify();
            mockClientWrapper.Verify();
    
        }
    }
