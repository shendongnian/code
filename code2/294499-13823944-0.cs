    public class User {
        public int Id {get;set;}
    }
    public class Message {
        public int Id {get;set;}
    }
    //The many-to-many association class with additional properties
    public class UserMessageLink {
        [Key]
        [Column("RecieverId", Order = 0)]
        [ForeignKey("Reciever")]
        public virtual int RecieverId { get; set; }
	
        [Key]
        [Column("MessageId", Order = 1)]
        [ForeignKey("Message")]
        public virtual int MessageId { get; set; }
        public virtual User Reciever { get; set; }
        public virtual Message Message { get; set; }
        //This is an additional property
        public bool IsRead { get; set; }
    }
