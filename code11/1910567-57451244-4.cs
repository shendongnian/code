    public class Recipe
    {
    
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Ingredients { get; set; }
    
        public string Image { get; set; }
    	
        [ForeignKey("Category")]
    	public int CategoryId { get; set; }
    
        public Category Category { get; set; }
    }
    
    public class Category
    {
    	[Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
    }
