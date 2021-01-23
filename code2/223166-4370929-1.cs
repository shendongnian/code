    [Test]
    public void TestFindById() {
        const int TEST_ID = 5;
        // Configure your mock DAO to return a real DomainBase 
        // when FindById is called.
        mockDao
            .Setup(dao => dao.FindById(TEST_ID, It.IsAny<Type>())
            .Returns(new DomainBase() { Id = TEST_ID });
        var domainObject = _hibernateService.FindById(TEST_ID , typeof(DomainBase));
        // Make sure the returned object is a DomainBase with id == TEST_ID 
        Assert.IsEqual(TEST_ID , domainObject.Id);
        Assert.IsInstanceOf<DomainBase>(domainObject);
        // and verify that your mock DAO was called with the same argument passed to 
        // your NHibernate service wrapper:
        mockDao.VerifyAll();
    }
