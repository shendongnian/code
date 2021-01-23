    using System;
    using System.Globalization;
    using System.IO;
    using System.Runtime.Serialization.Json;
    using System.Text;
    namespace SO6299496
    {
        class Program
        {
            static void Main()
            {
                var myDate = DateTime.Now;                
                var serializer = new DataContractJsonSerializer(typeof(DateTime));
                var ms = new MemoryStream();
                serializer.WriteObject(ms, myDate);
                Console.WriteLine(Encoding.UTF8.GetString(ms.ToArray()));
                Console.WriteLine(SerializeDate(myDate));
            }
            static string SerializeDate(DateTime value)
            {
                var epoch = new DateTime(1970, 01, 01, 01, 0, 0);
            
                long date = (value.ToUniversalTime().Ticks - epoch.Ticks) / 10000;
                string sign = "";
                string offset = "";
            
                if (value.Kind == DateTimeKind.Unspecified || value.Kind == DateTimeKind.Local)
                {
                        TimeSpan utcOffset = TimeZone.CurrentTimeZone.GetUtcOffset(value.ToLocalTime());
                        sign = utcOffset.Ticks >= 0L ? "+" : "-";
                        int offsetHours = Math.Abs(utcOffset.Hours);
                        int offsetMinutes = Math.Abs(utcOffset.Minutes);
                        offset = (offsetHours < 10) ? ("0" + offsetHours) : offsetHours.ToString(CultureInfo.InvariantCulture);
                        offset += (offsetMinutes < 10) ? ("0" + offsetMinutes) : offsetMinutes.ToString(CultureInfo.InvariantCulture);
                }
                return date + sign + offset;
            }
        }
    }
