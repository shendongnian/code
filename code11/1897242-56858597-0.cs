    public static class EntityExtensions
    {
        public static Processor<T> CreateProcessor<T>(this T entity)
            where T : DomainEntity
            => new Processor<T>(entity);
    }
