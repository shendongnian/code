    // Implementation of the repository
    // Does not expose Add to the ICategoryRepository !!!
    public class CategoryRepository : ICategoryRepository, IBloggingRepository
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
