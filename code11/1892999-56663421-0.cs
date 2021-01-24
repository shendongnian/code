        public class Test
        {
            [JsonProperty("Id")]
            public long Id { get; set; }
        
            [JsonProperty("Name")]
            public string Name { get; set; }
        
            [JsonProperty("Address")]
            public string Address { get; set; }
        
            [JsonProperty("Country")]
            public string Country { get; set; }
        
            [JsonProperty("Phone")]
            [JsonConverter(typeof(ParseStringConverter))]
            public long Phone { get; set; }
        }
    
    
    string data="Your Json String"
    
    var details = JsonConvert.DeserializeObject<Test>(data);
