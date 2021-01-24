csharp
public static DateTime AddDays(this DateTime dt, double days, TimeZoneInfo tz)
{
    // If the kind is Local or Utc, convert that point in time to the given time zone
    DateTimeKind originalKind = dt.Kind;
    if (originalKind != DateTimeKind.Unspecified)
    {
        dt = TimeZoneInfo.ConvertTime(dt, tz);
    }
    // Add days with respect to the wall time only
    DateTime added = dt.AddDays(days);
    // Resolve the added value to a specific point in time
    DateTimeOffset resolved = added.ToDateTimeOffset(tz);
    // Return only the DateTime portion, but take the original kind into account
    switch (originalKind)
    {
        case DateTimeKind.Local:
            return resolved.LocalDateTime;
        case DateTimeKind.Utc:
            return resolved.UtcDateTime;
        default: // DateTimeKind.Unspecified
            return resolved.DateTime;
    }
}
Here is another variation of that extension method.  This one operates on `DateTimeOffset` values:
csharp
public static DateTimeOffset AddDays(this DateTimeOffset dto, double days, TimeZoneInfo tz)
{
    // Make sure the input time is in the provided time zone
    dto = TimeZoneInfo.ConvertTime(dto, tz);
    // Add days with respect to the wall time only
    DateTime added = dto.DateTime.AddDays(days);
    // Resolve the added value to a specific point in time
    DateTimeOffset resolved = added.ToDateTimeOffset(tz);
    // Return the fully resolved value
    return resolved;
}
Both of the above methods depend on the following `ToDateTimeOffset` extension method (which I've used in a few different posts now).
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
Lastly, I'll point out that there is another option to consider:  Use the [Noda Time][1] library.  It's [`ZoneDateTime.Add`][2] method has exactly this purpose.
  [1]: https://nodatime.org/
  [2]: https://nodatime.org/api/NodaTime.ZonedDateTime.html#NodaTime_ZonedDateTime_Add_NodaTime_ZonedDateTime_NodaTime_Duration_
