    [TestMethod]
    public void TestingPropertyUsingAAA()
    {   
       // Arrange
       var mockPerson = MockRepository.GenerateStub<Person>();
       repository.Stub(x => x.Title).Return("Monica");
    
       // Act
       var someObject = new ObjectThatUsesPerson(mockPerson);
       someObject.SomeMethod(); // This internally calls Person.Title    
       // Assert
       repository.AssertWasCalled(x => x.Title);
    }
