    public static DateTime GetNextDateOrSomething(DateTime start, IEnumerable<DayOfWeek> weekdays)
    {
        if (!weekdays.Any()) throw new ArgumentException($"{nameof(weekdays)} cannot be empty.");
        var increments = Enumerable.Range(1, 6);
        var matchedIncrement = increments.FirstOrDefault(i => weekdays.Contains(start.AddDays(i).DayOfWeek));
        return start.AddDays(matchedIncrement > 0 ? matchedIncrement : 7);
    }
    [DataTestMethod]
    [DataRow("4/10/2019", "Wednesday,Thursday", "4/11/2019")]
    [DataRow("4/10/2019", "Thursday", "4/11/2019")]
    [DataRow("4/10/2019", "Monday,Tuesday", "4/15/2019")]
    [DataRow("4/10/2019", "Tuesday", "4/16/2019")]
    public void TestDateMethod(string start, string weekdays, string expected)
    {
        var startDate = DateTime.Parse(start);
        var weekDaysList = weekdays.Split(',').Select(d => (DayOfWeek)Enum.Parse(typeof(DayOfWeek), d));
        var expectedDate = DateTime.Parse(expected);
        var result = GetNextDateOrSomething(startDate, weekDaysList);
        Assert.AreEqual(expectedDate, result);
    }
