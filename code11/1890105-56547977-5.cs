    [TestClass]
    public class UploaderTests
    {
    	private Mock<IHttpService> _mockHttpService = new Mock<IHttpService>();
    
    	[TestMethod]
    	public async Task WhenStatusCodeIsNot200Ok_ThenErrorMessageReturned()
    	{
    		// arrange	
    		var uploader = new Uploader(_mockHttpService.Object);
    		var url = "someurl.co.uk";
    		var data = "data";
    		
    		// need to setup your mock to return the response you want to test
    		_mockHttpService
    			.Setup(s => s.PostAsync(url, data))
    			.ReturnsAsync(new HttpResponseMessage(HttpStatusCode.InternalServerError));
    		
    		// act
    		var result = await uploader.Upload(url, data);
    		
    		// assert
    		Assert.AreEqual("Some Error Message", result);		
    	}
        [TestMethod]
    	public async Task WhenStatusCodeIs200Ok_ThenNullReturned()
    	{
    		// arrange	
    		var uploader = new Uploader(_mockHttpService.Object);
    		var url = "someurl.co.uk";
    		var data = "data";
    		
    		// need to setup your mock to return the response you want to test
    		_mockHttpService
    			.Setup(s => s.PostAsync(url, data))
    			.ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK));
    		
    		// act
    		var result = await uploader.Upload(url, data);
    		
    		// assert
    		Assert.AreEqual(null, result);		
    	}
    }
