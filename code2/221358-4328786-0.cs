    public class userAttributeList
    {
        [XmlElement]
        public List<UserAttribute> attribute { get; set; }
    
        public UserAttributeList()
        {
            attribute = new List<UserAttribute>();
        }
    }
    
    public class UserAttribute
    {
        public String userId { get; set; }
        public String attId { get; set; }
        public String attName { get; set; }
        public String attTypeId { get; set; }
        public String attTypeName { get; set; }
        public String attData { get; set; }
    }
