    [TestClass]
    public class UnitTest1
    {
    	private Mock<ILogger> _mockLogger = new Mock<ILogger>();
    	private Mock<IDatabase> _mockDb = new Mock<IDatabase>();
    
    	[TestMethod]
    	public void TestMethod1()
    	{
            // arrange
    		var mainClass = new MainClass(_mockLogger.Object, _mockDb.Object);
    		var data = new Data();
            
            // act
    		mainClass.AddDetails(data);
            // assert    
    		_mockDb
    			.Verify(v => v.Add(data), Times.Once);
    	}
    }
