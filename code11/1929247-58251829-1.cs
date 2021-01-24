csharp
    public string IsWednesday() => IsWednesday(DateTime.Now);
    public string IsWednesday(DateTime time)
    {
        if (time.DayOfWeek == DayOfWeek.Wednesday)
        {
            return "It’s Wednesday";
        }
        else
        {
            return "It’s not Wednesday";
        }
    }
Then you can run the test with fixated dates, covering both cases "wednesday" and "not wednesday". This approach is an example of a general strategy: whatever is provided during normal execution by the environment (machine name, date, culture, etc) should be a parameter in the method under test, and the test bench should provide a range of significant values.
Regarding the actual tests (if I may, do yourself a favor and use NUnit or XUnit): they become trivial.
csharp
[TestMethod]
    public void ItsNotWednesday()
    {
        var wednesdayObj = new Wednesday();
        var result = wednesdayObj.IsWednesday(new DateTime(2019, 10, 5)); // Not a wednesday
        Assert.AreEqual("It’s not Wednesday", result);
    }
