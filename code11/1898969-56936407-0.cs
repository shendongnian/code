    void Main()
    {
        var document = new Document
        {
            Id = 123,
            Properties = {
                new Property { Name = "Filename", Value = "Mydocument.txt" },
                new Property { Name = "Length", Value = "1024" },
                new Property {
                    Name = "My secret property",
                    Value = "<insert world domination plans here>",
                    IsSerializable = false
                },
            }
        };
        
        var json = JsonConvert.SerializeObject(document, Formatting.Indented).Dump();
        var document2 = JsonConvert.DeserializeObject<Document>(json).Dump();
    }
    
    public class Document
    {
        public int Id { get; set; }
        
        [JsonConverterAttribute(typeof(PropertyListConverter))]
        public List<Property> Properties { get; } = new List<Property>();
    }
    
    public class Property
    {
        [JsonIgnore]
        public bool IsSerializable { get; set; } = true;
        public string Name { get; set; }
        public string Value { get; set; }
    }
    
    public class PropertyListConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(List<Property>);
        }
    
        public override object ReadJson(JsonReader reader, Type objectType,
            object existingValue, JsonSerializer serializer)
        {
            var list = (existingValue as List<Property>) ?? new List<Property>(); 
            list.AddRange(serializer.Deserialize<List<Property>>(reader));
            return list;
        }
    
        public override void WriteJson(JsonWriter writer, object value,
            JsonSerializer serializer)
        {
            var list = (List<Property>)value;
            var filtered = list.Where(p => p.IsSerializable).ToList();
            serializer.Serialize(writer, filtered);
        }
    }
