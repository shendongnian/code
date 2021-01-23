    [Table("TBL_USERS")]
    public class User
    {
        [Column("USER_ID")]
        public string UserId { get; set; }
        [Column("USER_NAME")]
        public string Name { get; set; }} 
