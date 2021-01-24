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
    
            Parent parent = JsonConvert.DeserializeObject<Parent>(str);
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
