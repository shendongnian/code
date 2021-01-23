    [Table("Table_UserImages")]
    public class UserImage
    {
        [Key, Column("UserID", Order=0)]
        public Guid? UserID { get; set; }
        [Key, Column("ImageID", Order=1)]
        public int? ImageID { get; set; }  
    }
