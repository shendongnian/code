    [DataContract]
    public sealed class Group
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "privacy")]
        public string Privacy { get; set; }
        [DataMember(Name = "id")]
        public string Id { get; set; }
    }
