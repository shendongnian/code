    [TestMethod]
    public void WhenValidRequest_ThenReturnSuccess()
    {
        Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
        personRepository.Setup(r => r.GetPerson()).Returns(
            new Person() 
            { 
                FirstName = "Joe",
                LastName = "Smith"
                /*...*/
            });
            
        Foo objectUnderTest = new Foo(personRepository.Object);
        bool result = objectUnderTest.MakeRequest(); 
        // Call method using the person repository that you want to test.
        // You don't actually care how the repository works, you just want to return a success 
        // boolean when a person exists for that request.
        
        Assert.IsTrue(result);
    } 
