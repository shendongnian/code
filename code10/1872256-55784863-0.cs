    public static class MixedRepositoryExtensions {
        public static Task<TEntity> FindBySelectorAsync<TEntity, TSelector>(
            this IReadableAndListableRepository<TEntity> repository,
            TSelector selector)
            where TEntity : class, ISearchableEntity<TSelector>
            => repository.Entities.SingleOrDefaultAsync(x => x.Matches(selector));
    }
