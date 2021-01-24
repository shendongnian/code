        using Newtonsoft.Json;
        using Newtonsoft.Json.Linq;
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        
        namespace ConsoleApp5
        {
            class Testclass
            {
                public string Data { get; set; }
                public string NoData { get; set; }
            }
            class JsonConverterObjectToString : JsonConverter
            {
                public override bool CanConvert(Type objectType)
                {
                    return (objectType == typeof(string));
                }
        
                public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
                {
                    JToken token = JToken.Load(reader);
                    if (token.Type == JTokenType.Object)
                    {
                        return token.ToString();
                    }
                    return null;
                }
        
                public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
                {
                    //serializer.Serialize(writer, value);
        
                    //serialize as actual JSON and not string data
                    var token = JToken.Parse(value.ToString());
                    writer.WriteToken(token.CreateReader());
        
                }
            }
            class Program
            {
        
                static void Main(string[] args)
                {
                    var json = "{\r\n  \"Data\": {\r\n    \"A\": {\r\n      \"A1\": \"S\",\r\n      \"A2\": 0.0\r\n    }\r\n  },\r\n  \"NoData\": \"text\"\r\n}";
                    var jObj = JsonConvert.DeserializeObject<Testclass>(json, new JsonConverterObjectToString());
                    var jObjStrin = JsonConvert.SerializeObject(jObj, new JsonConverterObjectToString());
     Console.WriteLine(jObjString);
                }
            }
        }
