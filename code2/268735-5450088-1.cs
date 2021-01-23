    public class ObjectThatUsesPerson
    {
        public ObjectThatUsesPerson(Person person)
        {
            this.person = person;
        }
        public void SomeMethod()
        {
            System.Console.WriteLine(person.Title);
        }
        private Person person;
    }
    [TestMethod]
    public void TestingProperty()
    {
        var mockPerson = MockRepository.GenerateMock<Person>();
        repository.Expect(x => x.Title).Return("Monica");
        repository.Replay();
        var someObject = new ObjectThatUsesPerson(mockPerson);
        someObject.SomeMethod(); // This internally calls Person.Title
        repository.VerifyAllExpectations();
    }
