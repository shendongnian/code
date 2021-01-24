    private readonly HomeController _homeController = new HomeController();
    [TestMethod]
    public void Staff_CheckCount()
    {
        var result = _homeController.Staff();
        Assert.IsInstanceOfType(result, typeof(ViewResult));
        var actual = ((ViewResult)result).Model as StaffDto[];
        Assert.IsNotNull(actual);
        Assert.AreEqual(3, actual.Length);
    }
