    public class SMAccount
    {
        [Key]
        public int Id { get; set; }
        public User User { get; set; }
        public string Type { get; set; }
        public string AId { get; set; }
    }
