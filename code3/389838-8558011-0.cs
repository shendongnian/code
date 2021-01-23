    public void AddOrUpdate(T item ,V repo) where T: IItem, V:IRepository
    { 
      repo.AddOrUpdate(item)
    }
    class Foo
    {
        IRepository _productRepository;
        IRepository _contentRepository
    
        private void Initialize(string dataSourceID)
        {
            _productRepository = StorageHelper.GetTable<Product>(dataSourceID);
            _contentRepository = StorageHelper.GetTable<Content>(dataSourceID);
            _ex = new ServiceException();
        }
    
        public void MethodForProduct(IItem item)
        {
           _productRepository.SaveOrUpdate(item);
        }
    
        public void MethodForContent(IItem item)
        {
           _contentRepository.SaveOrUpdate(item);
        }
    
    }
    
    // this is your repository extension class.
    public static RepositoryExtension
    {
    
       public static void SaveOrUpdate(this IRepository repository, T item) where T : IItem
       {
          repository.SaveOrUpdate(item);
       }
    
    }
    // you can also use a base class.
    interface IItem
    {
       ...
    }
    
    class Product : IItem
    {
      ...
    }
    
    class Content : IItem
    {
      ...
    }
