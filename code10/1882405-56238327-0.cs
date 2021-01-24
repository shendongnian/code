    using System;
    namespace MyProject {
      public sealed class GuidConverter : JsonConverter<Guid> {
        public GuidConverter() { }
        public GuidConverter(string format) { _format = format; }
        private readonly string _format = "N";
        public override void WriteJson(JsonWriter writer, Guid value, JsonSerializer serializer) {
          writer.WriteValue(value.ToString(_format));
        }
        public override Guid ReadJson(JsonReader reader, Type objectType, Guid existingValue, bool hasExistingValue, JsonSerializer serializer) {
          string s = (string)reader.Value;
          return new Guid(s);
        }
      }
    }
