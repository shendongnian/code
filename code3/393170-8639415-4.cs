    string str = JsonConvert.SerializeObject(new DateTimeClass(), new MyDateTimeConvertor());
    public class DateTimeClass
    {
        public DateTime dt;
        public int dummy = 0;
    }
    public class MyDateTimeConvertor : DateTimeConverterBase
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return DateTime.Parse(reader.Value.ToString());
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue( ((DateTime)value).ToString("dd/MM/yyyy") );
        }
    }
