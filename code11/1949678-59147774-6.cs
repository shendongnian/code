    public class Recipe
    {
        public Guid Id { get; set; }
    
        public virtual ICollection<Recipe> RelatedRecipes { get; set; } = new List<Recipe>();
    }
    public class RecipeConfiguration : EntityTypeConfiguration<Recipe>
    {
        public RecipeConfiguration()
        {
            ToTable("Recipes");
            HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
    
            HasMany(x => x.RelatedRecipes)
                .WithOptional()
                .Map(x => x.MapKey("BaseId"));
        }
    }
