    [TestMethod]
    public void Testing_Whether_Get_Returns_cellphone()
    {
        // Arrange
        RestClient restClient = new RestClient("http://pseudoUrl/Users");
        RestRequest restRequest = new RestRequest(Method.GET);
        restRequest.AddQueryParameter("UserId", "25248896");
        restRequest.AddHeader("headerType1", Guid.NewGuid().ToString());
        // Act
        IRestResponse restResponse = restClient.Execute(restRequest); 
        string response = restResponse.Content; // response = "[]"
        // Assert
        Assert.IsTrue(response.Contains("cellphone"));
    }
