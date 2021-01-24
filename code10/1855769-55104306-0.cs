    public class BulkEntityConverter : JsonConverter
        {
            public override object ReadJson(
                JsonReader reader,
                Type objectType,
                object existingValue,
                JsonSerializer serializer)
            {
                var obj = (JObject)JObject.ReadFrom(reader);
    
                JProperty property = obj.Properties().FirstOrDefault();
                // I didn't use this method
                return new BulkRegisterDto
                {
                    Id = property.Name,
                    Entities = new List<Person>()
                };
            }
    
            public override void WriteJson(
                JsonWriter writer,
                object value,
                JsonSerializer serializer)
            {
                BulkRegisterDto permission = (BulkRegisterDto)value;
    
                var innerEntities = new JObject();
                foreach (var entry in permission.Entities)
                {
                    innerEntities.Add(entry.Name, entry.Surname);
                }
    
                var root = new JObject
                {
                    { "id", permission.Id},
                    { "entities", new JArray { innerEntities } }
                };
    
                root.WriteTo(writer);
            }
    
            public override bool CanConvert(Type t)
            {
                return typeof(BulkRegisterDto).IsAssignableFrom(t);
            }
    
            public override bool CanRead
            {
                get { return true; }
            }
        }
