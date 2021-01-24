    public static class RepositoryExtension
    {
        public static IEnumerable<TEntity> GetAllWhere(this Repository repository)
        {
            return repository.GetAll().Where(x => x.isActive);
        }
    }
