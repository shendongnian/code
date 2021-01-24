    [Test]
    public void AbleToGetTheDatabaseNames() {
        //Arrange
        var mySql = new MySqlDb();
        //Act
        List<string> retVal = mySql.GetDatabaseNames();
        //Assert
        Assert.That(retVal, Has.Count.EqualTo(1));
    }
