        [DataContract]
        public class Dimension
        {
            [DataMember]
            public string Id { get; set; }
            [DataMember]
            public Members Members { get; set; }
    
        }
    
        //DataContractSerializer is the serializer by default.
        public class Members
        {
            public string ID { get; set; }
            public List<Member> Items { get; set; }    
        }
        public class Member 
        {
            public int Id { get; set; }
    }
