    [Test]
    public void Article_Action_Returns_Requested_Article()
    {
        // Arrange
        model = new Article();
        articleId = 1;
        Mock<IArticleRepository> repositoryMock = new Mock<IArticleRepository>();
        repositoryMock.Setup(x => x.GetById(articleId)).Returns(GetSampleArticle());
        controller = new HomeController(repositoryMock.Object);
        // Act
        ActionResult result = controller.Article(articleId);
        // Assert
        var viewResult = ((ViewResult)result);
        var returnedModel = viewResult.Model;
        Assert.IsInstanceOf<Article>(viewResult.Model);
        //Assert.AreEqual(articleId, returnedModel.ID);
    }
