    var mockedClass = new Mock<IDaoClass>();
    var classUnderTest = ...
    
    mockedClass.SetupGet(m => m.Persons).Returns(new List<Person>().AsQueryable());
    
    classUnderTest.DoSomething();
    
    mockedClass.Verify( m => m.Add(It.IsAny<Person>())); 
    mockedClass.Verify( m => m.Save());
