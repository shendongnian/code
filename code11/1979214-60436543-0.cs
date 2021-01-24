    public class Testata
    {
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-ddTHH:mm.fffZ")]
        public DateTime dt_doc { get; set; }
    }
    
    public class DateFormatConverter : IsoDateTimeConverter
    {
        public DateFormatConverter(string format)
        {
            DateTimeFormat = format;
        }
    }
