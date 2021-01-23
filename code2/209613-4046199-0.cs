    using System.Linq.Expressions;
    // ...
    public static IQueryable<Product> Search(Expression<Func<Product, bool>> search)
    {
        DBDataContext dc = new DBDataContext();
        return dc.Products.Where(search);
    }
