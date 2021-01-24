    [Test]
    public void AbleToGetTheDatabaseNames() {
        //Arrange
        var mySql = new MySqlDb();
        List<string> retVal = null;
        //Act
        Action act = () => retVal = mySql.GetDatabaseNames();
        //Assert
        Assert.That(act, Throws.Nothing);
        Assert.That(retVal, Has.Count.EqualTo(1));
    }
