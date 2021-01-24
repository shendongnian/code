internal static class ProductsHelper // -- STATIC
{
    // generic method that will work for all products 
    public static List<T> GetProducts<T>(IEnumerable<T> products, int count)
    {
        return products.Take(count).ToList();
    }
} 
