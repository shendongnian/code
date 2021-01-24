[TestMethod]
public void ShouldSetFirefoxOptions()
{
    // Arrange
    var stubCapabilities = new Mock<SauceCaps>().Object;	
	var optionCreatorMock = new Mock<IFirefoxOptionCreator>();
	optionCreatorMock.Setup(m => m.SetFirefoxOptions(It.IsAny<SauceCaps>()))
					 .Returns(new FirefoxOptions());
    var sut = new DriverManager();    
	
    // Act
	_ = sut.GetFirefoxDriver(stubCapabilities);
    // Assert
    optionCreatorMock.Verify(m => m.SetFirefoxOptions(stubCapabilities));
}
    
