    public class UserContact
    {
        public int Id { get; set; }
       
        // By Convention these 2 properties will be picked up as the FKs: 
        public int UserId { get; set; }
        public int ContactOptionId { get; set; }
        
        [Required]
        public User User { get; set; }        
        [Required]
        public ContactOption ContactOption { get; set; }
        public string Data { get; set; }
    }
