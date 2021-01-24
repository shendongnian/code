    [Test]
    public void AbleToGetTheDatabaseNames() {
        //Arrange
        List<string> retVal = null;
        //Act
        Action act = () => retVal = new MySqlDb.GetDatabaseNames();
        //Assert
        Assert.That(act, Throws.Nothing);
        Assert.That(retVal, Has.Count.EqualTo(1));
    }
