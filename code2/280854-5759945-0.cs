    public class User
    {
        [Key]
        public int? UserID { get; set; }
        /* Other properties */
        [Association("User_1-1_Address", "UserID", UserID", IsForeignKey = false)]
        [Include]
        public Address Address { get; set; }
    }
    public class Address
    {
        [Key]
        public int? UserID { get; set; }
        /* Other properties */
        [Association("User_1-1_Address", "UserID", UserID", IsForeignKey = true)]
        [Include]
        public User User{ get; set; }
    }
