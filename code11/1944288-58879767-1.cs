    [Fact]
    public async Task getCase_should_return_known_string()
    {
        var request = TestFactory.CreateHttpRequest("name", "Bill");
        var response = (OkObjectResult)await getCase.Run(request, logger);
        Assert.Equal("Hello, Bill", response.Value);
    }
    [Theory]
    [MemberData(nameof(TestFactory.Data), MemberType = typeof(TestFactory))]
    public async Task getCase_should_return_known_string_from_member_data(string queryStringKey, string queryStringValue)
    {
        var request = TestFactory.CreateHttpRequest(queryStringKey, queryStringValue);
        var response = (OkObjectResult)await getCase.Run(request, logger);
        Assert.Equal($"Hello, {queryStringValue}", response.Value);
    }
