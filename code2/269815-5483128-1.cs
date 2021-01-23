    public partial class User_role
    {
        [Key]
        public int user_id { get; set; }
        [Key]
        public int role_id { get; set; }
        public virtual Role Role { get; set; }
        public virtual App_user App_user { get; set; }
    }
