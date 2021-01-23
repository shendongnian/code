    string str = JsonConvert.SerializeObject(new DateTimeClass(), new MyDateTimeConvertor());
    public class DateTimeClass
    {
        public DateTime dt = DateTime.Now;
        public int dummy = 0;
    }
    public class MyDateTimeConvertor : Newtonsoft.Json.Converters.DateTimeConverterBase
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue( ((DateTime)value).ToString("dd/MM/yyyy") );
        }
    }
