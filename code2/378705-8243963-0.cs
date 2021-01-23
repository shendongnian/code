    public class Message
    {
        [Key] 
        public string Id { get; set;}
        public string ParentId { get; set; }
        [Include]
        public List<MailInfo> Email { get; set; }
    }
    
    public class MailInfo
    {
        [Key]
        public string Address { get; set; }
    }
