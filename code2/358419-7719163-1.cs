        [DataContract] 
        public interface IPerson
        {
           [DataMember]
           public int Identifier { get; set; }
           [DataMember]
           public string First { get; set; }
           [DataMember]
           public string Last { get; set; }
           public string GetSomething();
        }
