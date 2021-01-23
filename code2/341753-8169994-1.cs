    public void TestEmptyList()
    {
        var mock = new Mock<IRepository>();
        var expected = new List<EmployeeProfiles>();
        mock.SetupGet(ep => ep.EmployeeProfiles).Returns(expected);
        var actual = mock.Object.EmployeeProfiles;
        Assert.AreEqual(expected, actual);
    }
