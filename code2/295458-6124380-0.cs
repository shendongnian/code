    namespace TimeZoneTest
    {
      using System;
      using System.Globalization;
      class Program
      {
          static void Main(string[] args)
          {
              // get local time
              DateTime localTime = DateTime.Now;
              Console.WriteLine(string.Format(
                  CultureInfo.CurrentCulture, 
                  "localTime = {0}, localTime.Kind = {1}", 
                  localTime, 
                  localTime.Kind));
              // get local time zone, or use TimeZoneInfo to get any time zone you want
              TimeZone ltz = TimeZone.CurrentTimeZone;
              Console.WriteLine(string.Format("local time zone = {0}", ltz.StandardName));
              // convert local time to UTC
              DateTime utcTime = ltz.ToUniversalTime(localTime);
              Console.WriteLine(string.Format(CultureInfo.CurrentCulture,
                  "utcTime = {0}, utcTime.Kind = {1}",
                  utcTime,
                  utcTime.Kind));
              // transfer date via service, as ISO time string
              string isoUtc = utcTime.ToString("o");
              Console.WriteLine("...");
              Console.WriteLine(string.Format("transfer: isoUtc = {0}", isoUtc));
              Console.WriteLine("...");
              // now on the other side
              DateTime utcTimeRecieved = DateTime.ParseExact(
                  isoUtc, 
                  "o", 
                  CultureInfo.InvariantCulture, 
                  DateTimeStyles.RoundtripKind);
              Console.WriteLine(string.Format(CultureInfo.CurrentCulture, 
                  "utcTimeRecieved = {0}, utcTimeRecieved.Kind = {1}", 
                  utcTimeRecieved, 
                  utcTimeRecieved.Kind));
              // client time zone, or use TimeZoneInfo to get any time zone you want
              TimeZone ctz = TimeZone.CurrentTimeZone;
              Console.WriteLine(string.Format("client time zone = {0}", ctz.StandardName));
              // get local time from utc
              DateTime clientLocal = ctz.ToLocalTime(utcTimeRecieved);
              Console.WriteLine(string.Format(
                  CultureInfo.CurrentCulture,
                  "clientLocal = {0}, clientLocal.Kind = {1}",
                  clientLocal,
                  clientLocal.Kind));
              Console.WriteLine("\nPress any key to exit..");
              Console.ReadKey();
          }
      }
  }
