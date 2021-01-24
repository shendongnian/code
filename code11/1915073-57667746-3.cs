    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId {get;set;}
    
        public string UserName {get;set;}
    
        public DateTime BirthDate {get;set;}
    }
