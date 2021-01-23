    public class ProductManager
    {
        IRepository _repository;
        public ProductManager(IRepository repository)
        {
             _repository= repository;
        }
    }
