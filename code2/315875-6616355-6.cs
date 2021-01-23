    [Test]
    public void List()
    {
        Mock<IUserRepository> mockRepo = new Mock<IUserRepository>();
        mockRepo.Setup(ur => ur.GetAll()).Returns(MockedGetAll());
        var v = mockRepo.Object.GetAll();
    
        var controller = new UserController(mockRepo.Object);
        var result = controller.List() as ViewResult;
        var model = result.ViewData.Model as IQueryable<User>;
    
        Assert.AreEqual("List", result.ViewName);
        Assert.IsNotNull(model);
        Assert.Greater(model.Count(), 0);
    }
