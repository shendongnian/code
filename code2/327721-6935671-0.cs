    [DataContract]
    public class Result
    {
        [DataMember(Name = "recipe")]
        public Recipe Recipe { get; set; }
    }
    [DataContract]
    public class Recipe
    {
        [DataMember]
        public string thumb { get; set; }
        [DataMember]
        public string title { get; set; }
        [DataMember]
        public string source_url { get; set; }
    }
