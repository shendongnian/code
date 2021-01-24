class Entity
{
   [JsonProperty("id")]
   public string Id;
}
Then get a list of entities:
var json = "[{\"id\":\"1127889\"},{\"id\":\"1075442\"}, {\"id\":\"1201544\"}]";
var workingObject = JsonConvert.DeserializeObject<List<Entity>>(json);
var idList = new { id = (from c in workingObject select c.Id).ToArray()};
