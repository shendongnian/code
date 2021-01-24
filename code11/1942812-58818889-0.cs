 lang-cs
string inputDateString = "2019-11-12T09:00:00.000"; //Taken as input from user
string inputTimeZoneString = "(UTC-03:00) Brasilia"; // Taken as input from user
var dtStartdatetime = DateTime.Parse(inputDateString);
string sourceTimeZone = string.Empty;
foreach (TimeZoneInfo a in TimeZoneInfo.GetSystemTimeZones())
{
     if (a.DisplayName == inputTimeZoneString)
     {
          sourceTimeZone = a.Id;
		 break;
     }
     string strTimeZone = a.DisplayName.Substring(a.DisplayName.IndexOf(')') + 1);
     string strTimeZone1 = inputTimeZoneString.Substring(inputTimeZoneString.IndexOf(')') + 1);
     if (strTimeZone.Trim() == strTimeZone1.Trim())
     {
          sourceTimeZone = a.Id;
		 break;
     }
}
DateTime utc_time_start = TimeZoneInfo.ConvertTimeToUtc(dtStartdatetime, TimeZoneInfo.FindSystemTimeZoneById(sourceTimeZone));
Console.WriteLine(utc_time_start.ToString("yyyyMMddTHHmmssZ"));
