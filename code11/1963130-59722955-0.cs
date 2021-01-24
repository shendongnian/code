csharp
public class BaseClass
    {
        protected readonly IProductRepository _productoRepository;
        protected readonly ICategoryRepository _categoryRepository;
        protected readonly IImageRepository _imageRepository;
        public BaseClass(IProductRepository productoRepository, ICategoryRepository categoryRepository, IImageRepository imageRepository)
        {
            _productoRepository = productoRepository;
            _categoryRepository = categoryRepository;
            _imageRepository = imageRepository;
        }
this makes it for very standard and sensible way to set yourself up for dependency injection.
If you indeed wanted to have one different repo instance per class, then you might be better off Introducing a more generic `IRepository` and having it DI'd instead:
csharp
public class BaseClass
    {
        protected readonly IRepository _repository;
        public BaseClass(IRepository repository)
        {
            _repository= repository;
        }
if you want to have a bit more control over what implementations you will need in your derived classes, you can opt for generics:
csharp
public interface IRepository { }
public interface IProductRepository : IRepository { } // you can inherit interfaces
public interface ICategoryRepository : IRepository { }
public interface IImageRepository : IRepository { }
public class BaseClass<TRepo>  where TRepo : IRepository // we will require all generic parameters to be descendant of base interface
{
	protected readonly TRepo _repo;
	
	public BaseClass(TRepo repo)
	{
		_repo = repo;
	}
}
class Category : BaseClass<ICategoryRepository> {
	public Category(ICategoryRepository repo) : base(repo) {} // DI will inject a specific implementation
}
hopefully the outlined examples are applicable to you
