    public static void Add(Product product)
    {
        Repository.ProductTable.Add(product);
        Repository.SaveChanges();
    }
