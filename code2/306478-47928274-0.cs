    public partial class MyEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id{ get; set; }
    
        // Navigation
        [ForeignKey("id")]
        public PathEntity Path { get; set; }
    }
