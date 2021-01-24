    public class Movie
    {
        public int Id { get; set; }
    
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
    
        [CustomAnnotation(x,y,z)]
        [StringLength(1000)]
        public string Description { get; set; }
    
        [Range(0, 999.99)]
        public decimal Price { get; set; }
    
        [Required]
        public Genre Genre { get; set; }
    
        public bool Preorder { get; set; }
    }
