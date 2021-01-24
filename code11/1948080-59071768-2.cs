    //Arrrange
    Mock<IListOfthings> listOfThings = new Mock<IListOfthings>();
    var thing = new Thing {
        Name = "NameToFind",
        //...
    };
    List<Thing> list = new List<Thing>() { thing };
    
    listOfThings.Setup(_ => _.MyList).Returns(list);
    
    var subject = new ClassImTesting();
    
    //Act
    var actual = subject.Translate(listOfThings.Object);
    
    //Assert
    Assert.That(actual, Is.EqualTo(thing));
    
