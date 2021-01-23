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
        public int userId { get; set; }
        public int attId { get; set; }
        public string attName { get; set; }
        public int attTypeId { get; set; }
        public string attTypeName { get; set; }
        public string attData { get; set; }
    }
