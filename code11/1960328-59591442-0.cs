public class Proxy
{
    public string DroppableType { get; set; }
    public string SpriteFileName { get; set; }
    public float Probability { get; set; }
}
// before you serialize 
var result = yourDictionary.Select(t=> new Proxy { 
                Probability = t.Value, 
                DroppableType = t.DroppableType,
                SpriteFileName = t.SpriteFileName 
            }).ToArray();
// for deserializing it
var dictionary = deserialized.ToDictionary(r=> new YourType { r.DroppableType, r.SpriteFileName  },r=>Probability);
