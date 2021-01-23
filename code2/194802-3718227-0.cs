    [TestMethod()]
    public void NextSaturdayReturnsCorrectValueStartingFromASaturday()
    {
        DateTime date = DateTime.Parse("2010-08-14");
        
        DateTime expected = DateTime.Parse("2010-08-21");
        DateTime actual = DateExtensions.NextSaturday(date);
        
        Assert.AreEqual(expected, actual);
    }
    [TestMethod()]
    public void NextSaturdayReturnsCorrectValueWithinTheSameWeek() 
    {
        DateTime date = DateTime.Parse("2010-08-19");
        DateTime expected = DateTime.Parse("2010-08-21");
        DateTime actual = DateExtensions.NextSaturday(date);
        Assert.AreEqual(expected, actual);
    }
