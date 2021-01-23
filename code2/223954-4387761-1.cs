    public class ProductFactory : IProductFactory
    {
        private static Dictionary<int, Type> products =
            new Dictionary<int, Type>();
        static ProductFactory()
        {
            var productsWithId =
              from type in Assembly.GerCurrentExecutingAssembly().GetTypes()
              where typeof(IProduct).IsAssignableFrom(type)
              let attribute =
                  type.GetCustomAttributes(typeof(ProductAttribute))[0]
                      as ProductAttribute
              select new { type, attribue.Id };
            products = productsWithId.ToDictionary(p => p.Id, p => p.type);
        }
        public IProduct CreateInstanceById(int id)
        {
            Type productType = products[id];
            // Use your favorite way of creating that instance based on it's
            // type. For instance, you can use Activator.
            return new Activator.CreateInstance(productType);
        }
    }
