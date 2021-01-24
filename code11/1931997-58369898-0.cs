    public class Menu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }        
    
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    
        [ForeignKey("User")]
        public int UserId { get; set;}
    
        [Required]
        public User User { get; set; }
    
        [Required]
        public bool Active { get; set; }
    }
