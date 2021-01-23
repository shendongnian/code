    public interface IRepository
    {    
        IQueryable<IProduct> Products { get; set; }
        IQueryable<IProductCategory> Products { get; set; }
        IQueryable<ICategory> Products { get; set; }
        IQueryable<IProductImage> Products { get; set; }
    }
