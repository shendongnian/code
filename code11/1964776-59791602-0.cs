    [Test]
    public async Task Get_Single() {
        //Arrange
        TestSetup();
        var roleManagerWrapperMock = new Mock<IRoleManagerWrapper>();
        //...omitted for brevity
        var sut = new RolesController(roleManagerWrapperMock.Object, ApplicationDbContext, Mapper);
        //Act
        var result = await sut.GetSingle("4a8de423-5663-4831-ac07-7ce92465b008");
        //Assert
        Assert.AreEqual(result.UserCount, 1);
    }
