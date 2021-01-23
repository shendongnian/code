    [MetadataType(typeof(UserMetadata))]
    public class User
    {
        public string Name { get; set; }
    }
    public class UserMetadata
    {
       
        [Required]
        public object Name { get; set; }
    }
