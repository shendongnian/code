        [TestCase("~/page/myaction")]
        [TestCase("~/page/myaction/")]
        public void Page_With_Custom_Action(string virtualUrl) {
            
            // Arrange
            var pathData = new Mock<IPathData>();
            var pageModel = new Mock<IPageModel>();
            var repository = new Mock<IPageRepository>();
            var mapper = new Mock<IControllerMapper>();
            var container = new Mock<IContainer>();
            container.Setup(x => x.GetInstance<IPageRepository>()).Returns(repository.Object);
            repository.Setup(x => x.GetPageByUrl<IPageModel>(virtualUrl)).ReturnsInOrder(null, pageModel.Object);
            pathData.Setup(x => x.Action).Returns("myaction");
            pathData.Setup(x => x.Controller).Returns("page");
            var resolver = new DashboardPathResolver(pathData.Object, repository.Object, mapper.Object, container.Object);
            // Act
            var data = resolver.ResolvePath(virtualUrl);
            // Assert
            Assert.NotNull(data);
            Assert.AreEqual("myaction", data.Action);
            Assert.AreEqual("page", data.Controller);
        }
