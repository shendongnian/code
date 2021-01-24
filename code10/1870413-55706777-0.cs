    [TestCase(DayOfWeek.Monday, OlDaysOfWeek.olMonday)]
    [TestCase(DayOfWeek.Tuesday, OlDaysOfWeek.olTuesday)]
    [TestCase(DayOfWeek.Wednesday, OlDaysOfWeek.olWednesday)]
    [TestCase(DayOfWeek.Thursday, OlDaysOfWeek.olThursday)]
    [TestCase(DayOfWeek.Friday, OlDaysOfWeek.olFriday)]
    [TestCase(DayOfWeek.Saturday, OlDaysOfWeek.olSaturday)]
    [TestCase(DayOfWeek.Sunday, OlDaysOfWeek.olSunday)]
    public void AsDaysOfWeek(DayOfWeek dayOfWeek, OlDaysOfWeek expectedResult)
    {
        var result = dayOfWeek.AsDaysOfWeek();
        Assert.That(result, Is.EqualTo(expectedResult));
    }
