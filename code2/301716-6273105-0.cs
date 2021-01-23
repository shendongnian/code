    [TestMethod]
    public void Test_Cache()
    {
        var Service = new Service(_mockRepository.Object, _mockLogger.Object, _mockCacheStorage.Object);
        
        _mockCacheStorage.SetupGet(g => g.Get<List<Csa>>(It.IsAny<string>).Returns(new List<Csa>());
        Service.GetAll();
   
        _mockRepository.Verify(r => r.FindAll(), Times.Never());
    }
