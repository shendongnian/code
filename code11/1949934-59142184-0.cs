    class Program
    {
        static void Main(string[] args)
        {
            var dbResult = new Product
            {
                ProductItems = new List<ProductItem>
                {
                    new ProductItem {CreatedDate = null, ProductName = "SomeProduct"},
                    new ProductItem {CreatedDate = DateTime.Now, ProductName = "SomeProduct2"},
                    new ProductItem {CreatedDate = DateTime.UtcNow, ProductName = "SomeProduct3"}
                }
            };
            
            Console.WriteLine("Default Linq Ordering\n");
            var result = dbResult.ProductItems?.OrderByDescending(x => x.CreatedDate).ToList();
            if (result != null)
            {
                foreach (var productItem in result)
                {
                    Console.WriteLine("{0} Created Date: {1} \n", productItem.ProductName, productItem.CreatedDate);
                }
                Console.WriteLine("Set null ordering to Datetime.Max\n");
            }
            result = dbResult.ProductItems?.OrderByDescending(x => x.CreatedDate ?? DateTime.MaxValue).ToList();
            if (result != null)
            {
                foreach (var productItem in result)
                {
                    Console.WriteLine("{0} Created Date: {1} \n", productItem.ProductName, productItem.CreatedDate);
                }
            }
            Console.ReadLine();
        }
    }
    public class Product
    {
        public List<ProductItem> ProductItems { get; set; }
    }
    public class ProductItem {
        public DateTime? CreatedDate { get; set; }
        public string ProductName { get; set; }
    }
