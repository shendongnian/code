    [Fact]
    public async Task GetPendingApprovals_HasPending_ReturnsResultAsync() {
        // Arrange
        var mockRequests = getUsers();
        var userId = 1;
        mockServiceRepo
            .Setup(repo => repo.GetUserID(It.IsAny<string>()))
            .ReturnsAsync(userId);
        
        mockRequestRepo
            .Setup(repo => repo.GetPendingApprovalsByApprover(userId))
            .ReturnsAsync(mockRequests);
        // Act
        var result = await controller.GetPendingApprovals();
        // Assert
        var actionResult = Assert.IsType<OkObjectResult>(result);
        
        //...
    }
    List<Request> getUsers() {
        //... omitted for brevity
    }
