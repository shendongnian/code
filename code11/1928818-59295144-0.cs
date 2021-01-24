    using Dahomey.Json;
    using Dahomey.Json.Attributes;
    using System.Text.Json;
    public class ObjectWithDefaultValue
    {
        [JsonIgnoreIfDefault]
        [DefaultValue(12)]
        public int Id { get; set; }
    
        [JsonIgnoreIfDefault]
        [DefaultValue("foo")]
        public string FirstName { get; set; }
    
        [JsonIgnoreIfDefault]
        [DefaultValue("foo")]
        public string LastName { get; set; }
    
        [JsonIgnoreIfDefault]
        [DefaultValue(12)]
        public int Age { get; set; }
    }
