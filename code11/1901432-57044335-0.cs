csharp
using NodaTime;
using System;
using System.Linq;
namespace TestingApp
{
    class Program
    {
        static void Main(string[] args)
        {            
            var tz = DateTimeZoneProviders.Tzdb["Europe/Paris"];
            
            var localDates = new[]
            {
                new LocalDate(1995, 9, 23),
                new LocalDate(1995, 9, 24),
                new LocalDate(1995, 10, 28),
                new LocalDate(1995, 10, 29)
            };
            var midday = new LocalTime(12, 0, 0);
            var localDateTimes = localDates.Select(date => date.At(midday));
            
            foreach (var localDateTime in localDateTimes)
            {
                var utc = localDateTime.InZoneStrictly(tz).WithZone(DateTimeZone.Utc);
                Console.WriteLine($"Paris: {localDateTime:yyyy/MM/dd HH:mm:ss} -> UTC: {utc:yyyy/MM/dd HH:mm:ss}");
            }
        }
    }
}
