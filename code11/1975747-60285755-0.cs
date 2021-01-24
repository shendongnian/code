public class Product
    {
        public int ProductID { get; internal set; }
        public string ProductName { get; internal set; }
        public Brand brand { get; set; }
        public Category cat { get; set; }
        public Product()
        {
            brand = new Brand();
            cat = new Category();
        }
    }
    public class Brand
    {
        public int BrandID { get; internal set; }
        public string BrandName { get; internal set; }
    }
    public class Category
    {
        public int CategoryID { get; internal set; }
        public string CategoryName { get; internal set; }
    }
private void a1()
{
    var products = new List<Product>{
    new Product { ProductID = 1,
                                brand =new Brand { BrandID = 1, BrandName = "Brand1" },
                                cat = new Category { CategoryID = 1, CategoryName = "cat1" },
                                ProductName = "Product1" },
    new Product { ProductID = 2,
                                brand =new Brand { BrandID = 1, BrandName = "Brand1" },
                                cat = new Category { CategoryID = 1, CategoryName = "cat1" },
                                ProductName = "Product2" },
    new Product { ProductID = 3,
                                brand =new Brand { BrandID = 1, BrandName = "Brand1" },
                                cat = new Category { CategoryID = 2, CategoryName = "cat2" },
                                ProductName = "Product3" },
    new Product { ProductID = 4,
                                brand =new Brand { BrandID = 2, BrandName = "Brand2" },
                                cat = new Category { CategoryID = 1, CategoryName = "cat1" },
                                ProductName = "Product4" }
    };
    var g1 = products.GroupBy(p => new { p.brand, p.cat, p })
                        .Select(y => new 
                        {
                            k1 = y.Key.brand.BrandName,
                            k2 = y.Key.cat.CategoryName,
                            k3 = y.Key.p.ProductName
                        }       
                        );
}
// Result/Output as below
{ k1 = "Brand1", k2 = "cat1", k3 = "Product1" }
{ k1 = "Brand1", k2 = "cat1", k3 = "Product2" }
{ k1 = "Brand1", k2 = "cat2", k3 = "Product3" }
{ k1 = "Brand2", k2 = "cat1", k3 = "Product4" }
