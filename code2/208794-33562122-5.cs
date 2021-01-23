    [DataContract]
    public class Document {
        [DataMember] 
        public string Title { get; set; }
        [DataMember] 
        public DateTime? Modified { get; set; } 
    }
