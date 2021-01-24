var rst = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");
var dayInSpecificTimezone = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, rst); // Got the datetime in specified timezone
Console.WriteLine("RST datetime now is {0}", dayInSpecificTimezone);
var sameTimeTheDayAfterThat = dayInSpecificTimezone.AddDays(1);
Console.WriteLine("RST datetime in 1 day is {0}", sameTimeTheDayAfterThat);
Console.WriteLine("local datetime in 1 day is {0}", TimeZoneInfo.ConvertTime(sameTimeTheDayAfterThat, rst, TimeZoneInfo.Local));
would give output similar to:
RST datetime now is 29/01/2020 4:31:14 AM
RST datetime in 1 day is 30/01/2020 4:31:14 AM
local datetime in 1 day is 30/01/2020 1:31:14 PM
