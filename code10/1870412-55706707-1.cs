public OlDaysOfWeek ConvertToDaysOfWeek(DayOfWeek day)
{
  switch (day)
  {
    case DayOfWeek.Monday: return OlDaysOfWeek.olMonday;
    case DayOfWeek.Tuesday: return OlDaysOfWeek.olTuesday;
    case DayOfWeek.Wednesday: return OlDaysOfWeek.olWednesday;
    case DayOfWeek.Thursday: return OlDaysOfWeek.olThursday;
    case DayOfWeek.Friday: return OlDaysOfWeek.olFriday;
    case DayOfWeek.Saturday: return OlDaysOfWeek.olSaturday;
    case DayOfWeek.Sunday: return OlDaysOfWeek.olSunday;
    default: throw new ArgumentOutOfRangeException("What day is this?", "day");
  }
}
Alternatively, you could probably parse the value and return the mapped value based on the enum value name.
public OlDaysOfWeek ConvertToDaysOfWeek(DayOfWeek day)
{
  return (OlDaysOfWeek) Enum.Parse(typeof(OlDaysOfWeek), "ol" + day.ToString());
}
The `OlDaysOfWeek` enum utilises a power-of-2 sequence, which is typically used when combining values as bitwise flags. `DaysOfWeek` has a simple linear sequence reflected as 0-6 - this is why you can't compare using the backing `int` value
