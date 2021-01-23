    [TestMethod]
    [Tag("Property")]
    public void FirstNameTest()
    {
        var expected = "John";
        var sut = new CustomerViewModel();
        
        sut.Firstname = expected;
        
        Assert.AreEqual(expected, sut.Firstname);
    }
