    public static IEnumerable<Product> Filter(
        this IEnumerable<Product> productEnum,
        Func<Product, bool> selectorParam)
        {
            return productEnum.Where(x => !x.IsExpired).Where(selectorParam);
        }
