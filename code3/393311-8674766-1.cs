    [TestMethod]
    public void GetCity_TakesParId_ReturnsParis
    {
        ICityObtainer cityObtainer = new CityObtainer();
        var result = cityObtainer.GetCity("paris");
        Assert.That(result.Name, Is.EqualTo("paris");
    }
