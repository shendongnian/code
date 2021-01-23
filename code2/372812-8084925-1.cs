    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json.Converters;
    namespace JsonArrayImplictConvertTest
    {
        public class MMArrayConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return objectType.Equals(typeof(List<string>));
            }
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.StartArray)
                {
                    List<string> parseList = new List<string>();
                    do
                    {
                        if (reader.Read())
                        {
                            if (reader.TokenType == JsonToken.String)
                            {
                                parseList.Add((string)reader.Value);
                            }
                            else
                            {
                                if (reader.TokenType == JsonToken.Null)
                                {
                                    parseList.Add(null);
                                }
                                else
                                {
                                    if (reader.TokenType != JsonToken.EndArray)
                                    {
                                        throw new ArgumentException(string.Format("Expected String/Null, Found JSON Token Type {0} instead", reader.TokenType.ToString()));
                                    }
                                }
                            }
                        }
                        else
                        {
                            throw new InvalidOperationException("Broken JSON Input Detected");
                        }
                    }
                    while (reader.TokenType != JsonToken.EndArray);
                    return parseList;
                }
                if (reader.TokenType == JsonToken.Null)
                {
                    // TODO: You need to decide here if we want to return an empty list, or null.
                    return null;
                }
                if (reader.TokenType == JsonToken.String)
                {
                    List<string> singleList = new List<string>();
                    singleList.Add((string)reader.Value);
                    return singleList;
                }
                throw new InvalidOperationException("Unhandled case for MMArrayConverter. Check to see if this converter has been applied to the wrong serialization type.");
            }
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                // Not implemented for brevity, but you could add this if needed.
                throw new NotImplementedException();
            }
        }
        public class ModifiedXX
        {
            public string yy { get; set; }
            [JsonConverter(typeof(MMArrayConverter))]
            public List<string> mm { get; set; }
            public void Display()
            {
                Console.WriteLine("yy is {0}", this.yy);
                if (null == mm)
                {
                    Console.WriteLine("mm is null");
                }
                else
                {
                    Console.WriteLine("mm contains these items:");
                    mm.ForEach((item) => { Console.WriteLine("  {0}", item); });
                }
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                string jsonTest1 = "{\"yy\":\"nn\", \"mm\": [ \"zzz\", \"aaa\" ] }";
                ModifiedXX obj1 = JsonConvert.DeserializeObject<ModifiedXX>(jsonTest1);
                obj1.Display();
                string jsonTest2 = "{\"yy\":\"nn\", \"mm\": \"zzz\" }";
                ModifiedXX obj2 = JsonConvert.DeserializeObject<ModifiedXX>(jsonTest2);
                obj2.Display();
                // This test is now required in case we messed up the parser state in our converter.
                string jsonTest3 = "[{\"yy\":\"nn\", \"mm\": [ \"zzz\", \"aaa\" ] },{\"yy\":\"nn\", \"mm\": \"zzz\" }]";
                List<ModifiedXX> obj3 = JsonConvert.DeserializeObject<List<ModifiedXX>>(jsonTest3);
                obj3.ForEach((obj) => { obj.Display(); });
                Console.ReadKey();
            }
        }
    }
