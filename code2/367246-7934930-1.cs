    public class User
    {
        [Key]   
        public int user_id {get;set;}
        public string username {get;set;}
        public string email {get;set;}
        public virtual User_Profile user_profile {get;set;}
    }
    public class User_Profile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int user_id {get;set;}
        public string firstname {get;set;}
        public string lastname {get;set;}
    }
