    [DataContract]
    public class Document {
        [DataMember] 
        public string Title { get; set; }
        [DataMember(IsRequired = false, EmitDefaultValue = false)] 
        public DateTime Modified { get; set; } 
    }
