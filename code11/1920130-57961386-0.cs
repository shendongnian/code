csharp
public static DateTimeOffset ToDateTimeOffset(this DateTime dt, TimeZoneInfo tz)
{
    if (dt.Kind != DateTimeKind.Unspecified)
    {
        // Handle UTC or Local kinds (regular and hidden 4th kind)
        DateTimeOffset dto = new DateTimeOffset(dt.ToUniversalTime(), TimeSpan.Zero);
        return TimeZoneInfo.ConvertTime(dto, tz);
    }
    if (tz.IsAmbiguousTime(dt))
    {
        // Prefer the daylight offset, because it comes first sequentially (1:30 ET becomes 1:30 EDT)
        TimeSpan[] offsets = tz.GetAmbiguousTimeOffsets(dt);
        TimeSpan offset = offsets[0] > offsets[1] ? offsets[0] : offsets[1];
        return new DateTimeOffset(dt, offset);
    }
    if (tz.IsInvalidTime(dt))
    {
        // Advance by the gap, and return with the daylight offset  (2:30 ET becomes 3:30 EDT)
        TimeSpan[] offsets = { tz.GetUtcOffset(dt.AddDays(-1)), tz.GetUtcOffset(dt.AddDays(1)) };
        TimeSpan gap = offsets[1] - offsets[0];
        return new DateTimeOffset(dt.Add(gap), offsets[1]);
    }
    // Simple case
    return new DateTimeOffset(dt, tz.GetUtcOffset(dt));
}
Now that you have that defined (and put it in a static class somewhere in your project), you can call it where needed in your application.
For example:
csharp
TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
DateTime dt = new DateTime(2019, 3, 10, 2, 0, 0, DateTimeKind.Unspecified);
DateTimeOffset dto = dt.ToDateTimeOffset(tz);  // 2019-03-10T03:00:00-04:00
or
csharp
TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
DateTime dt = new DateTime(2019, 11, 3, 1, 0, 0, DateTimeKind.Unspecified);
DateTimeOffset dto = dt.ToDateTimeOffset(tz);  // 2019-11-03T01:00:00-04:00
or
csharp
TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
DateTime dt = new DateTime(2019, 3, 10, 0, 0, 0, DateTimeKind.Unspecified);
DateTimeOffset midnight = dt.ToDateTimeOffset(tz);                     // 2019-03-10T00:00:00-05:00
DateTimeOffset oneOClock = midnight.AddHours(1);                       // 2019-03-10T01:00:00-05:00
DateTimeOffset twoOClock = oneOClock.AddHours(1);                      // 2019-03-10T02:00:00-05:00
DateTimeOffset threeOClock = TimeZoneInfo.ConvertTime(twoOClock, tz);  // 2019-03-10T03:00:00-04:00
TimeSpan diff = threeOClock - oneOClock;  // 1 hour
Note that subtracting two `DateTimeOffset` values correctly considers their offsets (whereas subtracting two `DateTime` values completely ignores their `Kind`).
  [1]: https://nodatime.org/
