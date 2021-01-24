    class MyDbContext : DbContext
    {
        public DbSet<Recipe> Recipes {get; set;}
        public DbSet<Ingredient> Ingredients {get; set;}
    }
    class Recipe
    {
        public int Id {get; set;}  // primary key
        ...                        // other columns
        // every Recipe has zero or more ingredients (many-to-many)
        public virtual ICollection<Ingredient> Ingredients {get; set;}
    }
    class Ingredient
    {
        public int Id {get; set;}  // primary key
        ...                        // other columns
        // every Ingredient is used in zero or more Recipes( many-to-many)
        public virtual ICollection<Recipe> Recipes {get; set;}
    }
