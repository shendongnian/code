    public abstract class BaseUnit
        {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
    
            [Required, MaxLength(300)]
            public string Title { get; set; }
    
            [Required, AllowHtml]
            public string Content { get; set; }
        }
