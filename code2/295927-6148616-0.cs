    [TestMethod]
    public void VerifyThatMyDatabaseConnectionStringExists()
    {
        Assert.IsNotNull(ConfigurationManager.ConnectionStrings["DomainDatabase"]);
    }
