    public class OAuthUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(100)]
        public string Id { get; set; }
    
        ...........
    }
