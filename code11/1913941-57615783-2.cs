    [TestFixture]
    public class TemplateComponentTests {
        
        private Mock<IFileService> fileService;
        private Mock<ITemplateFactory> templateFactory;
        private TemplateComponent component;
        string templateAlias = "aldusBlog";
        [SetUp]
        public void SetUp() {
            //Arrange
            fileService = new Mock<IFileService>();
            templateFactory = new Mock<ITemplateFactory>();
            templateFactory.Setup(_ => _.Create(It.IsAny<string>(), It.IsAny<string>()))
                .Returns((string name, string alias) => 
                    Mock.Of<ITemplate>(_ => _.Alias == alias && _.Name == name)
                );
            component = new TemplateComponent(fileService.Object, templateFactory.Object);
        }
        [Test]
        public void Initialise_WhenCalled_GetsBlogTemplate() {
            //Act
            component.Initialize();
            //Assert
            fileService.Verify(s => s.GetTemplate(templateAlias), Times.Once);
        }
        [Test]
        public void Initialise_BlogTemplateDoesNotExist_CreateTemplate() {
            //Act
            component.Initialize();
            //Assert
            fileService.Verify(s => s.SaveTemplate(It.Is<ITemplate>(p => p.Alias == templateAlias), 0), Times.Once());
        }
    }
