    public enum ProductGroupEnum
        {
            Today = 0,
            Yesterday = 1,
            Last30Days = 30
        }
    
        public static class ProductsHelper
        {
            public static List<Product> GetProductsGroup(ProductGroupEnum group, IEnumerable<Product> products)
            {
                var daysCount = (int)group;
    
                return products.Where(x => DateTime.Now.Date - x.Date.Date <= new TimeSpan(daysCount, 0, 0, 0)).ToList();
            }
        }
