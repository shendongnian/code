    using Newtonsoft.Json;
    namespace JsonUriSerializeTest
    {
        class Program
        {
            public class UriConverter : JsonConverter
            {
                public override bool CanConvert(Type objectType)
                {
                    return objectType.Equals(typeof(Uri));
                }
                public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
                {
                    if (reader.TokenType == JsonToken.String)
                    {
                        return new Uri((string)reader.Value);
                    }
                    if (reader.TokenType == JsonToken.Null)
                    {
                        return null;
                    }
                    throw new InvalidOperationException("Unhandled case for UriConverter. Check to see if this converter has been applied to the wrong serialization type.");
                }
                public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
                {
                    if (null == value)
                    {
                        writer.WriteNull();
                        return;
                    }
                    if (value is Uri)
                    {
                        writer.WriteValue(((Uri)value).OriginalString);
                        return;
                    }
                    throw new InvalidOperationException("Unhandled case for UriConverter. Check to see if this converter has been applied to the wrong serialization type.");
                }
            }
            public class UriPair
            {
                public string label { get; set; }
                public Uri first { get; set; }
                public Uri second { get; set; }
                public void Display()
                {
                    Console.WriteLine(string.Format("label:  {0}", label));
                    Console.WriteLine(string.Format("first:  {0}", first));
                    Console.WriteLine(string.Format("second: {0}", second));
                }
            }
            static void Main(string[] args)
            {
                string input = "http://test.com/%22foo+bar%22";
                Uri uri = new Uri(input);
                string json = JsonConvert.SerializeObject(uri, new UriConverter());
                Uri output = JsonConvert.DeserializeObject<Uri>(json, new UriConverter());
                Console.WriteLine(input);
                Console.WriteLine(output.ToString());
                Console.WriteLine();
                UriPair pair = new UriPair();
                pair.label = input;
                pair.first = null;
                pair.second = new Uri(input);
                string jsonPair = JsonConvert.SerializeObject(pair, new UriConverter());
                UriPair outputPair = JsonConvert.DeserializeObject<UriPair>(jsonPair, new UriConverter());
                outputPair.Display();
                Console.WriteLine();
                Console.ReadKey();
            }
        }
    }
