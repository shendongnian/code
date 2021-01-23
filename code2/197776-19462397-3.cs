    [Table("UserProfile")]
    [MetadataType(typeof(UserProfileMetadata))]
    public partial class UserProfile
    {
        internal sealed class UserProfileMetadata
        {
            [Key]
            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int UserId { get; set; }
        }
    }
