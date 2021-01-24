using Newtonsoft.Json.Linq;
using System;
using System.Globalization;
using TimeZoneConverter;
namespace ParseJsonDateTimeZone
{
    class Program
    {
        static void Main(string[] args)
        {
            string json = "{\"id\": 1,\"zoneDate\":{\"zone\":\"Europe/Paris\",\"dateTime\":\"2019-04-02T00:00:00\"}}";
            Console.WriteLine(new Model(json));
        }
        public class Model
        {
            public Model(string json)
            {
                JObject jObject = JObject.Parse(json);
                Id = (int) jObject["id"];
                JToken zoneDate = jObject["zoneDate"];
                TimeZoneInfo tzi;
                try
                {
                    tzi = TZConvert.GetTimeZoneInfo(zoneDate["zone"].ToString());
                }
                catch(TimeZoneNotFoundException)
                {
                    // Fallback to UTC or do something else?
                    tzi = TZConvert.GetTimeZoneInfo("UTC");
                }
                CultureInfo culture = CultureInfo.InvariantCulture;
                DateTime dateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.Parse(zoneDate["dateTime"].ToString()), tzi);
                DateTime = TimeZoneInfo.ConvertTime(dateTime, tzi );
            }
            public int Id { get; set; }
            public DateTime DateTime { get; set; }
        }
    }
}
