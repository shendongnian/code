public class EntityDescription 
{
  public string ProductDescription { get; set; }
}
public class Entity
{
   public string Product { get; set; }
}
public class Source : Entity 
{
   [JsonProperty("to_Description")]
   public EntityDescription[] Description { get; set; }
}
public class Target : Entity 
{
   [JsonProperty("to_Description")]
   public EntityDescription Description { get; set; }
}
var raw = File.ReadAllText(@"output.json");
var source = JsonConvert.DeserializeObject<Source>(raw);
var target = new Target { Product = source.Product, Description = source.Description.FirstOrDefault() };
var rawResult = JsonConvert.SerializeObject(target);
