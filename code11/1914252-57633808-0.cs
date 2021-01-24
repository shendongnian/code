    [Test]
    [TestCase("aldusBlogComposition")]
    public void Initialise_WhenCalled_SavesComposition(string alias) {
        //Arrange
        IContentType contentType = Mock.Of<IContentType>(_ => _.ALias == alias);
    
        _blogContentTypeFactory
            .Setup(_ => _.GetComposition())
            .Returns(contentType);
    
        //Act
        _component.Initialize();
    
        //Assert
        _contentTypeService.Verify(s => s.Save(It.Is<IContentType>(ct => ct.Alias == alias), It.IsAny<int>()), Times.Once);
    }
