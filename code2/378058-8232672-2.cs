    public static class MyExtensions
    {
        public static int? GetId(this Context db, Type entityType, string name)
        {
            return ((IQueryable<DomainEntity>)db.Set(entityType))
                .Where(x => x.Name == name)
                .Select(x => (int?)x.Id)
                .FirstOrDefault();
        }
    }
