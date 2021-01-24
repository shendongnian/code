    public static class Program
    {
        static void Main(string[] args)
        {
            string str = @"{
                    'name': 'Child1',
                    'Children': {
                        'item-1253': {
                            'id': 'car',
                            'type': 'car'
                        },
                        'item-4343': {
                            'id': 'car',
                            'type': 'car'
                        }
                    }
                }";
    
    		// Way 1) Using POCO
            Parent parent = JsonConvert.DeserializeObject<Parent>(str);
    		
    		// Way 2) Using dynamic
                dynamic deserializedDynamicObject = JsonConvert.DeserializeObject<dynamic>(str);
    
    		// Way 3) Using JObject
    		JObject deserializedJObject = JsonConvert.DeserializeObject<JObject>(str);
    		List<JObject> childrenObjects = deserializedJObject["Children"]
    										.Cast<JProperty>()
    										.Select(x => x.Value)
    										.Cast<JObject>()
    										.ToList();
        }
    }
    
    public class Parent
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    
        [JsonProperty("Children")]
        public Dictionary<string, Item> Children { get; set; }
    }
    
    public class Item
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    
        [JsonProperty("type")]
        public string Type { get; set; }
    }
