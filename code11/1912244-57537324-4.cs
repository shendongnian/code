    // Exposes the IBloggingRepository methods to ICategoryRepository
    public interface ICategoryRepository : IBloggingRepository
    {
    }
    // Implementation of the repository
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;
        private readonly IBloggingRepository _bloggingRepo;
        public CategoryRepository(DataContext context, IBloggingRepository bloggingRepository) 
        {
            _context = context;
            _bloggingRepo = bloggingRepository;
        }
        // The implementation of the Add method
        public void Add<T>(T entity) where T : class
        {
            _bloggingRepo.Add(entity);
        }
    }
