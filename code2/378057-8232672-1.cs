    public static class MyExtensions
    {
        public static int? GetId<TEntity>(this Context db, string name)
            where TEntity : DomainEntity
        {
            return db.Set<TEntity>()
                .Where(x => x.Name == name)
                .Select(x => (int?)x.Id)
                .FirstOrDefault();
        }
    }
