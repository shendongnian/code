    [Serializable]
    [DataContract]
    public class MyObject {
        [DataMember(Name = "id")]
        public int ID { get; set; }
    
        [DataMember(Name = "name")]
        public string Name { get; set; }
    
        [DataMember(Name = "first_name")]
        public string FirstName { get; set; }
    
        [DataMember(Name = "last_name")]
        public string LastName { get; set; }
    }
