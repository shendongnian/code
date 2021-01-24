    public class Person
    {
        public string name {get;set;}
        public string surname {get;set;}
        [BsonExtraElements]
        public Dictionary<string,object> AdditionalFields { get; set; }
    }
