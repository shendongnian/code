    [Test]
    public void TestSaveDomainBase() {
    
        const int OBJECT_ID = 5;
    
        mockDao
          .Setup(dao => dao.Save(It.IsAny<DomainBase>()))
          .Callback((DomainBase d) => {
             // Make sure the object passed to Delete() was the correct one
             Assert.AreEqual(OBJECT_ID, d.ID);
          });
        var objectToSave = new DomainObject() { Id = OBJECT_ID };
 
        _hibernateService.Save(objectToDelete);
        mockDao.VerifyAll();
    }
    [Test]
    public void TestDeleteDomainBase() {
    
        const int OBJECT_ID_TO_DELETE = 5;
    
        mockDao
          .Setup(dao => dao.Delete(It.IsAny<DomainBase>()))
          .Callback((DomainBase d) => {
             // Make sure the object passed to Delete() was the correct one
             Assert.AreEqual(OBJECT_ID_TO_DELETE, d.ID);
          });
        var objectToDelete = new DomainObject() { Id = OBJECT_ID_TO_DELETE };
 
        _hibernateService.Delete(objectToDelete);
        mockDao.VerifyAll();
    }
