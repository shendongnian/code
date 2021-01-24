    public class Book
    {
        [Column("Id", TypeName = "LONGTEXT")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
    
        [Required, StringLength(100, MinimumLength = 1)]
        public string Title { get; set; }
    }
