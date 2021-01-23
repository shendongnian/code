    public interface IProductFactory: IEntityFactory
    {
        Product Get(string productId);
        IList<Product> GetAll();
        int GetAllCount();
    }
