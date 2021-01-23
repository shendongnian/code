    public class RepositoryProvider
    {
        public RepositoryProvider(ObjectContext context, IEnumerable<IFilteredRepositoryFactory> repositoryFactories)
        {
            _context = context;
            _repositoryFactories = repositoryFactories;
        }
        private readonly ObjectContext _context;
        private readonly IEnumerable<IFilteredRepositoryFactory> _repositoryFactories;
        private readonly Dictionary<Type, IRepository> _loadedRepositories;
        IRepository this[Type repositoryType]
        {
            get
            {
                if(_loadedRepositories.ContainsKey(repositoryType))
                {
                    return _loadedRepositories[repositoryType];
                }
                var repository = GetFactory(repositoryType).CreateRepository(repositoryType, _context);
                _loadedRepositories.Add(repositoryType,repository);
                return repository;
            }
        }
        IFilteredRepositoryFactory GetFactory(Type repositoryType)
        {
            //throws an exception if no repository factory is found
            return _repositoryFactories.First(x => x.CanCreateRepository(repositoryType));
        }
    }
