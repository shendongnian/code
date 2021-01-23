    public static class DbSetExtensions
    {
		public static EntityEntry<TEnt> AddIfNotExists<TEnt, TKey>(this DbSet<TEnt> dbSet, TEnt entity, Func<TEnt, TKey> predicate) where TEnt : class
		{
			var exists = dbSet.Any(c => predicate(entity).Equals(predicate(c)));
			return exists
				? null
				: dbSet.Add(entity);
		}
		public static void AddRangeIfNotExists<TEnt, TKey>(this DbSet<TEnt> dbSet, IEnumerable<TEnt> entities, Func<TEnt, TKey> predicate) where TEnt : class
		{
			var entitiesToAdd = entities as TEnt[] ?? entities.ToArray();
			var entitiesExist = entitiesToAdd.Where(e => dbSet.Any(c => predicate(e).Equals(predicate(c))));
			dbSet.AddRange(entitiesToAdd.Except(entitiesExist));
		}
	}
