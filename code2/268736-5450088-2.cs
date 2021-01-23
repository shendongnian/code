    public class ObjectThatUsesPerson
    {
        public ObjectThatUsesPerson(Person person)
        {
            this.person = person;
        }
        public string SomeMethod()
        {
            return person.Title;
        }
        private Person person;
    }
    [TestMethod]
    public void TestingPropertyGotCalled()
    {
        // Arrange
        var mockPerson = MockRepository.GenerateMock<Person>();
        mockPerson.Expect(x => x.Title).Return("Monica");
        var someObject = new ObjectThatUsesPerson(mockPerson);
        // Act
        someObject.SomeMethod(); // This internally calls Person.Title
        // Assert
        repository.VerifyAllExpectations();
        // or: mockPerson.AssertWasCalled(x => x.Title);
    }
    [TestMethod]
    public void TestingMethodResult()
    {
        // Arrange
        var stubPerson = MockRepository.GenerateStub<Person>();
        stubPerson.Stub(x => x.Title).Return("Monica");
        var someObject = new ObjectThatUsesPerson(stubPerson);
        // Act
        string result = someObject.SomeMethod();
        // Assert
        Assert.AreEqual("Monica", result, "Expected SomeMethod to return correct value");
    }
