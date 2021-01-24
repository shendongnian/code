csharp
using System;
using NodaTime;
class Test
{
    static void Main()
    {
        var duration = GetDurationToNext(
            IsoDayOfWeek.Sunday, new LocalTime(21, 30),
            DateTimeZoneProviders.Tzdb["Europe/Paris"],
            SystemClock.Instance);
        
        Console.WriteLine($"Duration: {duration}");
    }
    
    static Duration GetDurationToNext(
        IsoDayOfWeek dayOfWeek,
        LocalTime timeOfDay,
        DateTimeZone zone,
        IClock clock) // Or just take an instant
    {
        var now = clock.GetCurrentInstant();
        var localNow = now.InZone(zone).LocalDateTime;
        
        var localNext = localNow
            .Date.With(DateAdjusters.NextOrSame(dayOfWeek))
            .At(timeOfDay);
        // Handle "we're already on the right day-of-week, but
        // later in the day"
        if (localNext <= localNow)
        {
            localNext = localNext.PlusWeeks(1);
        }
        
        var zonedNext = localNext.InZoneLeniently(zone);
        var instantNext = zonedNext.ToInstant();
        return instantNext - now;
    }
}
