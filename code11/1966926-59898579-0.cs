csharp
using NodaTime.TimeZones;
using System;
using System.Linq;
class Program
{
    static void Main()
    {
        DisplayCountryInfo("Europe/London");
        DisplayCountryInfo("Asia/Kolkata");
    }
    static void DisplayCountryInfo(string id)
    {
        var source = TzdbDateTimeZoneSource.Default;
        Console.WriteLine($"ID: {id}");
        if (!source.GetIds().Contains(id))
        {
            Console.WriteLine("ID not found. Aborting");
            Console.WriteLine();
            return;
        }
        var canonicalId = source.CanonicalIdMap[id];
        Console.WriteLine($"Canonical ID: {canonicalId}");
        var location = source.ZoneLocations.FirstOrDefault(loc => loc.ZoneId == canonicalId);
        if (location is null)
        {
            Console.WriteLine($"No location found.");
        }
        else
        {
            Console.WriteLine($"Country: {location.CountryName}");
            Console.WriteLine($"Code: {location.CountryCode}");
        }
        Console.WriteLine();
    }
}
Output:
text
ID: Europe/London
Canonical ID: Europe/London
Country: Britain (UK)
Code: GB
ID: Asia/Kolkata
Canonical ID: Asia/Kolkata
Country: India
Code: IN
Note that the code is "IN" rather than "IND"; "IN" is the ISO-3166 country code for India.
