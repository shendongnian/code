    public IQueryable<Product> Search( Func<Product, bool> isMatch )
    {
       DBDataContext dc = new DBDataContext();
       return dc.Products.Where( isMatch );
    }
