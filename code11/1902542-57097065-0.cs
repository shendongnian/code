    [Fact]
    public async Task CreateCSVFile_Failure() {
        //Arrange
        var dtData = new DataTable();
        string fileName = "";
        var mockClient = new Mock<IHttpHandler>();
        this._iADLS_Operations = new ADLS_Operations(mockClient.Object);
        mockClient
            .Setup(repo => repo.PostAsync(It.IsAny<string>(), It.IsAny<HttpContent>(), It.IsAny<string>()))
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.BadRequest));
        mockClient
            .Setup(repo => repo.SendAsync(It.IsAny<HttpRequestMessage>(), It.IsAny<string>()))
            .ThrowsAsyc<Exception>();
        //Act 
        Func<Task> act = () => this._iADLS_Operations.CreateCSVFile(dtData, fileName);
        //Assert
        Exception ex = await Assert.ThrowsAsync<Exception>(act);
        Assert.Contains("Exception occurred while executing method:", ex.Message);
    }
