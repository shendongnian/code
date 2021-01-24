[Flags]
public enum DaysOfWeek
{
    Sunday = 1 << 0,
    Monday = 1 << 1,
    Tuesday = 1 << 2,
    Wednesday = 1 << 3,
    Thursday = 1 << 4,
    Friday = 1 << 5,
    Saturday = 1 << 6,
}
Since own enum has same order of days, we can write extension method to convert standard DayOfWeek to own
public static class EnumExtensions
{
    public static DaysOfWeek ToFlag(this DayOfWeek dayOfWeek)
    {
        var mask = 1 << (int)dayOfWeek;
        return (DaysOfWeek)Enum.ToObject(typeof(DaysOfWeek), mask);
    }
}
And usage:
  
      var days = DaysOfWeek.Sunday | DaysOfWeek.Friday;
      var day = DayOfWeek.Sunday;
      var ownDay = day.ToFlag();
      if (days.HasFlag(ownDay))
          // Do whatever;
playground: https://dotnetfiddle.net/sV3yge
