    public static class MixedRepositoryExtensions {
        public static Task<TEntity> FindBySelectorAsync<TEntity>(
            this IReadOnlyRepository<TEntity> repository,
            ISelector<TEntity> selector
        ) where TEntity : class
            => repository.Entities.SingleOrDefaultAsync(x => selector.Matches(x));
    }
