    public class Foo
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    
        [JsonProperty("contentType")]
        public object ContentType { get; set; }
    
        [JsonProperty("content")]
        public object Content { get; set {
                //do something here with `value` e.g.
                RelationshipContent = value; //change as required
                DomainContent = value; //change as required
            }
        }
    
        [JsonIgnore]
        public Relationship RelationshipContent { get; set; }
    
        [JsonIgnore]
        public Domains DomainContent { get; set; }
    
    }
