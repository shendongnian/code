    [Test]
    public void Test()
    {
        // Arrange
        var p1 = new Person();
        var p2 = new Person();
        Session.Save(p1);
        Session.Save(p2);
    
        // Act
        var result = new PersonQuery().GetAll();
    
        // Assert
        var firstPerson = result[0];
        var secondPerson = result[1];
        Assert.AreEqual(p1.Id, firstPerson.Id);
        Assert.AreEqual(p2.Id, secondPerson.Id);        
    }
