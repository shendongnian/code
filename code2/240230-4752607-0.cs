    [JsonObject(MemberSerialization.OptIn)]
    public class Person
    {
        [JsonProperty]
        public string name{get;set;}
        [JsonProperty]
        public string email{get;set;}
    }
