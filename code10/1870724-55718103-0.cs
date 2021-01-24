    void Main()
    {
        string json = @"{""RoadRef"":""L1""}";
        var data = JsonConvert.DeserializeObject<Foo>(json);
    }
    
    public class RoadConverter : JsonConverter<Road>
    {
    
        public override bool CanWrite => false;
    
        public override void WriteJson(JsonWriter writer, Road value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    
        public override Road ReadJson(JsonReader reader, Type objectType, Road existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.ValueType != typeof(string))
                return (Road)serializer.Deserialize(reader, objectType);
    
            var data = reader.Value as string;
            return new Road(data);
        }
    }
    
    
    public class Foo
    {
        [JsonConverter(typeof(RoadConverter))]
        public Road RoadRef { get; set; }
    }
    
    public class Road
    {
        public Road(string val)
        {
            Lane = val[0];
            Number = int.Parse(val.Substring(1));
        }
    
        public char Lane { get; set; }
        public int Number { get; set; } = 1;
    }
