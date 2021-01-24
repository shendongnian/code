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
