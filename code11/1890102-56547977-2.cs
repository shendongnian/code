    [TestClass]
    public class UploaderTests
    {
    	private Mock<IHttpService> _mockHttpService = new Mock<IHttpService>();
    
    	[TestMethod]
    	public async Task Upload()
    	{
    		// arrange	
    		var uploader = new Uploader(_mockHttpService.Object);
    		var url = "someurl.co.uk";
    		var data = "data";
    		
    		// need to setup your mock to return the response you want to test
    		_mockHttpService
    			.Setup(s => s.PostAsync(url, data))
    			.ReturnsAsync(new HttpResponseMessage());
    		
    		// act
    		var result = uploader.Upload(url, data);
    		
    		// assert
    		Assert.AreEqual(expected, result);		
    	}
    }
