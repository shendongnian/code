    [DataContract]
    public class Root
    {
        [DataMember]
        public string MemberString { get{ return (string)this.Member; } set{this.Member=(Element)value;} }
    
        public Element Member { get; set; }
    }
