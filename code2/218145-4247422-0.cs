    public virtual IDictionary<Product, int> JsonProducts
    {
        get
        {
            return new Dictionary(Products);
        }
    }
