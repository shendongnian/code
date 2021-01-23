    public class Organisation {
      public string Name { get; set; }
    
      [JsonConverter(typeof(RichDudeConverter))]
      public IPerson Owner { get; set; }
    }
    
    public interface IPerson {
      string Name { get; set; }
    }
    
    public class Tycoon : IPerson {
      public string Name { get; set; }
    }
    
    public class Magnate : IPerson {
      public string Name { get; set; }
      public string IndustryName { get; set; }
    }
    
    public class Heir: IPerson {
      public string Name { get; set; }
      public IPerson Benefactor { get; set; }
    }
    
    public class RichDudeConverter : JsonConverter
    {
      public override bool CanConvert(Type objectType)
      {
        return (objectType == typeof(IPerson));
      }
    
      public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
      {
        // pseudo-code
        object richDude = serializer.Deserialize<Heir>(reader);
        
        if (richDude == null)
        {
            richDude = serializer.Deserialize<Magnate>(reader);
        }
    
        if (richDude == null)
        {
            richDude = serializer.Deserialize<Tycoon>(reader);
        }
        
        return richDude;
      }
    
      public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
      {
        // Left as an exercise to the reader :)
        throw new NotImplementedException();
      }
    }
