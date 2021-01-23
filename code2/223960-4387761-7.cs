    public class ProductFactory : IProductFactory
    {
        private static Dictionary<int, Type> products =
            new Dictionary<int, Type>();
        static ProductFactory()
        {
            // Please note that this query is a bit simplistic. It doesn't
            // handle error reporting.
            var productsWithId =
              from type in 
                  Assembly.GetExecutingAssembly().GetTypes()
              where typeof(IProduct).IsAssignableFrom(type)
              where !type.IsAbstract && !type.IsInterface
              let attributes = type.GetCustomAttributes(
                typeof(ProductAttribute), false)
              let attribute = attributes[0] as ProductAttribute
              select new { type, attribute.Id };
            products = productsWithId
                .ToDictionary(p => p.Id, p => p.type);
        }
        public IProduct CreateInstanceById(int id)
        {
            Type productType = products[id];
            
            return Activator.CreateInstance(productType) as IProduct;
        }
    }
