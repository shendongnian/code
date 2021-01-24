    [Theory]
    [InlineData("", typeof(OkObjectResult))]
    [InlineData(null, typeof(BadRequestObjectResult))]
    public async Task Get_Return_Something(param1, param2){
        
        // moq MyController with its parameters/objects
        ...
    
    
        var result = await sut.Get(param1);
        result.ShouldBeOfType(param2);
    }
