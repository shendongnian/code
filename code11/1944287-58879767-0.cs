    [Fact]
    public async Task getCase_should_return_known_string()
    {
        var request = TestFactory.CreateHttpRequest("name", "Bill");
        var response = (OkObjectResult)await getCase.Run(request, logger);
        Assert.Equal("Hello, Bill", response.Value);
    }
