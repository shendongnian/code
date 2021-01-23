    var dayLightChangeEnd = TimeZone.CurrentTimeZone.GetDaylightChanges(DateTime.Now.Year).End.ToUniversalTime();
    var stillInDaylightSavingTime = dayLightChangeEnd.Subtract(TimeSpan.FromMinutes(62)).ToLocalTime();
    Console.WriteLine(stillInDaylightSavingTime);
    Console.WriteLine(stillInDaylightSavingTime.IsDaylightSavingTime());
    var noDaylightSavingTimeAnymore = dayLightChangeEnd.Subtract(TimeSpan.FromMinutes(2)).ToLocalTime();
    Console.WriteLine(noDaylightSavingTimeAnymore);
    Console.WriteLine(noDaylightSavingTimeAnymore.IsDaylightSavingTime());
