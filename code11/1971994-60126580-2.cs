    public class OAuthUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(50)]
        public string Id { get; set; }
    
        ...........
    }
