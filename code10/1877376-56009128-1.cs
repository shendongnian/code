    [JsonConverter(typeof(GoodCassConverter))]
    public class GoodClass
    {
        public MemberOfMyType MemberOfMyType { get; set; }
        public string SomeOtherMemberOfClass { get; set; }
    }
    public class GoodClassConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            MyGoodClass myclass = value as MyGoodClass;
    
            writer.WriteValue(myclass..); //do your thing here.
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            MyGoodClass myclass = new MyGoodClass();
            myclass.SomeOtherMemberOfClass = (string)reader.Value; //do some stuffs with the string here.
    
            return myclass;
        }
    
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(MyGoodClass);
        }
    }
