    class Program
    {
        static void Main(string[] args)
        {
            var products = new List<Product>{
                new Product { ProductID = 1, BrandID = 1, CategoryID = 1, ProductName = "Product1" },
                new Product { ProductID = 2, BrandID = 1, CategoryID = 1, ProductName = "Product2" },
                new Product { ProductID = 3, BrandID = 1, CategoryID = 2, ProductName = "Product3" },
                new Product { ProductID = 4, BrandID = 2, CategoryID = 1, ProductName = "Product4" }
            };
            var groupedByBrand = 
                products
                    .GroupBy(p => p.BrandID)
                    .Select(g => g.GroupBy(p => p.CategoryID));
            foreach (var groupByBrand in groupedByBrand)
                foreach (var groupByCategory in groupByBrand)
                    foreach (var product in groupByCategory)
                        Console.WriteLine($"{product.BrandID} - {product.ProductName}");
        }
    }
    
    public class Product
    {
        public int ProductID { get; internal set; }
        public int BrandID { get; internal set; }
        public int CategoryID { get; internal set; }
        public string ProductName { get; internal set; }
    }
