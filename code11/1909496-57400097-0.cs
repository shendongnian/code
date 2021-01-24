    public class ClassToTest
    {
        private readonly IService _service;
        public ClassToTest(IService service) =>
            _service = service;
        public IList<Products> GetProducts(string categoryId)
        {
            return _service.Get(new Category { id = categoryId, flag = true });
        }
    }
    public interface IService
    {
        IList<Products> Get(Category category);
    }
