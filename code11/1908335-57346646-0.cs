    [TestMethod]
    public async Task GenerateTokenAsync_WhenExecuted_WithoutProperties_ShouldFail() {
        // Arrange
        IAzureClient azureClient = new AzureClient(); //Assuming name here
        ArgumentException actual = null;
    
        // Act
        try {
            var token = await azureClient.GenerateTokenAsync();
        } catch(ArgumentException ex) {
            actual = ex;
        }
    
        // Assert
        actual.Should().NotBeNull();
    }
