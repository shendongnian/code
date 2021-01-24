c#
    public class MyDateTimeConverter : IsoDateTimeConverter
    {
        public MyDateTimeConverter()
        {
            //Take care of the format here 
            base.DateTimeFormat ="yyyy-MM-dd(HH:mm)";
        }
    }
    
    [JsonConverter(typeof(MyDateTimeConverter))]
    public DateTime Date { get; set; }
