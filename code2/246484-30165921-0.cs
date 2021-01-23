    public class FunctionConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(String));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, String.Concat("<Function>", value, "</Function>"));
        }
    }
    public static class JsonObjectExtensions
    {
        public static String CleanJson(this String s)
        {
            return s.Replace("\"<Function>", "").Replace("</Function>\"", "");
        }
    }
    public partial class JsonObject
    {
        public String ToJson()
        {
            return JsonConvert.SerializeObject(this).CleanJson();
        }
    }
