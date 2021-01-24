    public class Recipe
    {
    
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Ingridients { get; set; }
    
        public string Image { get; set; }
    	
    	public int CategoryId { get; set; }
    
        public Category category { get; set; }
    }
    
    public class Category
    {
    	[Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Recipe> Recipes { get; set; }
    }
