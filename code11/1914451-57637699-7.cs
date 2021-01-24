    [Fact(DisplayName = "Create a Project Context")]
    public void CreateProjectContext() {
        // Arrange
        var collectionMock = Mock.Of<IMongoCollection<Project>>();
        var dbMock = new Mock<IMongoDatabase>();
        dbMock.Setup(_ => _.GetCollection<Project>(It.IsAny<string>()))
            .Returns(collectionMock);
        // Act
        var result = new ProjectsContext(dbMock.Object);
        // Assert
        result.Should().NotBeNull()
            .And.BeAssignableTo<IProjectsContext>();
        //Write a test to assert the ProjectCollection
        result.Projects.Should().Be(collectionMock);
    }
