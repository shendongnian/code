    public class Recipe
    {
        public Guid Id { get; set; }
    
        public virtual Recipe BaseRecipe { get; set; }
        public virtual ICollection<Recipe> RelatedRecipes { get; set; } = new List<Recipe>();
    }
