    public class RecipeConfiguration : EntityTypeConfiguration<Recipe>
    {
        public RecipeConfiguration()
        {
            ToTable("Recipes");
            HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
    
            HasOptional(x => x.BaseRecipe)
                .WithMany(x => x.RelatedRecipes)
                .Map(x => x.MapKey("BaseId"));
        }
    }
