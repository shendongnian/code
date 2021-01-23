    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Table("Products");
            Id(x => x.ProductId);
            References(x => x.Category).Column("CategoryId");
        }
    }
    
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Table("Categories");
            Id(x => x.CategoryId);
            HasMany(x => x.Products).KeyColumn("ProductId");
        }
    }
