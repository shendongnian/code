    public Product GetProductByID(int id)
    {
        return new DbContext().Products
                              .FirstOrDefault(p => p.Pid == id);
    }
