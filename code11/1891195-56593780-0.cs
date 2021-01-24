    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationDbContext RepositoryContext { get; set; }
        public RepositoryBase(ApplicationDbContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }
        public async Task<PaginatedList<T>> FindAll()
        {
            return await PaginatedList<T>.CreateAsync(this.RepositoryContext.Set<T>(),1,2,null, null);
        }       
    }
