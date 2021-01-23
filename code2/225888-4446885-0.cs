    [Test]
    public void TestSearchOnAllProperties()
    {
        var localMockService = new Mock<IHibernateService>();
        var localApi = new Api(localMockService.Object);
    
        localMockService
            .Setup(service => service.LoadAll(It.IsAny<Type>()))
            .Returns(new DomainBase[0]);
    
        var dmbs = localApi.SearchOnAllProperties("search term", typeof(DomainBase));
    
        localMockService.VerifyAll();
    }
