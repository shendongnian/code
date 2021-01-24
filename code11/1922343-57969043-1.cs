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
**Update** For dynamic JSON
var jObject = JObject.Parse(File.ReadAllText(@"output.json"));
var newjObject = new JObject();
foreach(var jToken in jObject) {
  if(jToken.Value is JArray) {
    List<JToken> l = jToken.Value.ToObject<List<JToken>>();
      if(l != null && l.Count > 0) {
          newjObject.Add(jToken.Key, l.First());    
             }
       } else {
          newjObject.Add(jToken.Key, jToken.Value);
       }
    }
               
   var newTxt = newjObject.ToString();
