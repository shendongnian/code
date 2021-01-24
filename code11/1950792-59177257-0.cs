    using System;
    using System.Collections.Generic;
    
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    
    namespace TestProject
    {
    
        public partial class ImageResult
        {
            [JsonProperty("test", NullValueHandling = NullValueHandling.Ignore)]
            public Test[] Test { get; set; }
        }
    
        public partial class Test
        {
            [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
            public string Url { get; set; }
    
            [JsonProperty("width", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(ParseStringConverter))]
            public long? Width { get; set; }
    
            [JsonProperty("height", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(ParseStringConverter))]
            public long? Height { get; set; }
        }
    
        public partial class ImageResult
        {
            public static ImageResult FromJson(string json) => JsonConvert.DeserializeObject<ImageResult>(json, TestProject.Converter.Settings);
        }
    
        public static class Serialize
        {
            public static string ToJson(this ImageResult self) => JsonConvert.SerializeObject(self, TestProject.Converter.Settings);
        }
    
        internal static class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters =
                {
                    new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
                },
            };
        }
    
        internal class ParseStringConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);
    
            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                long l;
                if (Int64.TryParse(value, out l))
                {
                    return l;
                }
                throw new Exception("Cannot unmarshal type long");
            }
    
            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (long)untypedValue;
                serializer.Serialize(writer, value.ToString());
                return;
            }
    
            public static readonly ParseStringConverter Singleton = new ParseStringConverter();
        }
    }
