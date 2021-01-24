c#
var now = DateTime.UtcNow;
try
{
   var thaiZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
   var thaiTime = TimeZoneInfo.ConvertTimeFromUtc(now, thaiZone);
   Console.WriteLine("The date and time in SE Asia Standard Time is {0} {1}", thaiTime, thaiZone.IsDaylightSavingTime(thaiTime) ? thaiZone.DaylightName : thaiZone.StandardName);
}
catch (TimeZoneNotFoundException)
{
   Console.WriteLine("The registry does not define the SE Asia Standard Time zone.");
}                           
catch (InvalidTimeZoneException)
{
   Console.WriteLine("Registry data on the SE Asia Standard Time zone has been corrupted.");
}
Where `thaiTime` is the current time in Thailand (SE Asia Standard Time)
