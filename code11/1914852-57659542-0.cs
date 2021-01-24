    public abstract class BaseIngredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal KiloPrice { get; }
    }
    public class RawMaterial : BaseIngredient
    {
        public decimal KiloPrice { get; set; }
    }
    public class Recipe : BaseIngredient
    {
        public new decimal KiloPrice =>
            RecipeLines.Sum(x => x.Ingredient.KiloPrice * x.Quantity) /
            RecipeLines.Sum(x => x.Quantity);
        public virtual ICollection<RecipeLine> RecipeLines { get; set; }
    }
    public class RecipeLine
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public int BaseIngredientId { get; set; }
        public BaseIngredient Ingredient { get; set; }
        public decimal Quantity { get; set; }
    }
    public class SqliteDbContext :DbContext
    {
        public DbSet<RawMaterial> RawMaterials { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeLine> RecipeLines { get; set; }
        public DbSet<BaseIngredient> BaseIngredients { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RawMaterial>().ToTable("RawMaterial");
            modelBuilder.Entity<Recipe>().ToTable("Recipe");
            modelBuilder.Entity<BaseIngredient>().ToTable("BaseIngredient");
            modelBuilder.Entity<RawMaterial>()
                .HasBaseType<BaseIngredient>();
            modelBuilder.Entity<Recipe>()
                .HasBaseType<BaseIngredient>();
            modelBuilder.Entity<BaseIngredient>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<BaseIngredient>("BaseIngredient")
                .HasValue<RawMaterial>("RawMaterial")
                .HasValue<Recipe>("Recipe");
            modelBuilder.Entity<RecipeLine>()
                .HasOne(x => x.Ingredient);
            modelBuilder.Entity<RecipeLine>()
                .HasOne(x => x.Recipe)
                .WithMany(x => x.RecipeLines)
                .HasForeignKey(x => x.RecipeId);
        }
    }
