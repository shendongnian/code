    // Arrange
    //need common user id
    var userUuid = Guid.NewGuid().ToString();
    //create workspaces to satisfy Linq Count(Expression)
    var workspaces = Enumerable.Range(0, 10).Select(i => new Workspace {
        Name = Guid.NewGuid().ToString(),
        UserUuid = userUuid, //<-- Note the common user id
        WorkspaceId = i + 1
    });
    Mock<IWorkspacesRepo> mock = new Mock<IWorkspacesRepo>();
    //set up the property to return the list
    mock.Setup(_ => _.Workspaces).Returns(workspaces);
    var target = new WorkspaceBusinessService(mock.Object, null);
    var redundantWorkspace = new Workspace {
        Name = Guid.NewGuid().ToString(),
        UserUuid = userUuid, //<-- Note the common user id
        WorkspaceId = 11
    };
    // Act
    Action act = () => target.CreateWorkspace(redundantWorkspace);
    //Assert
    var ex = Assert.Throws<RpcException>(act);
    Assert.That(ex.Message, Is.EqualTo("Status(StatusCode.Aborted, \"There are no free slots work workspaces\")"));
