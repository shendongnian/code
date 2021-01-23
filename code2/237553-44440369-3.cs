    public class JsonXmlConverter<TType> : JsonConverter where TType : class
    {
        private static readonly XmlSerializer xmlSerializer = new XmlSerializer(typeof(TType));
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var xml = ToXml(value as TType);
            using (var stream = new StringReader(xml))
            {
                var xDoc = XDocument.Load(stream);
                var json = JsonConvert.SerializeXNode(xDoc);
                writer.WriteRawValue(json);
            }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) 
            { 
                // consume the 'null' token to set the reader in the correct state
                JToken.Load(reader); 
                return null; 
            }
            var jObj = JObject.Load(reader);
            var json = jObj.ToString();
            var xDoc = JsonConvert.DeserializeXNode(json);
            var xml = xDoc.ToString();
            return FromXml(xml);
        }
        public override bool CanRead => true;
        public override bool CanConvert(Type objectType) => objectType == typeof(TType);
        private static TType FromXml(string xmlString)
        {
            using (StringReader reader = new StringReader(xmlString))
                return (TType)xmlSerializer.Deserialize(reader);
        }
        private static string ToXml(TType obj)
        {
            using (StringWriter writer = new StringWriter())
            using (XmlWriter xmlWriter = XmlWriter.Create(writer))
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add(String.Empty, String.Empty);
                xmlSerializer.Serialize(xmlWriter, obj, ns);
                return writer.ToString();
            }
        }
    }
