    public interface IIntPersistentEntityService<TPersistentEntity>
            : IPersistentEntityService<TPersistentEntity, int>
        where TPersistentEntity : IPersistentEntity<int>
    {
    }
    public interface IStringPersistentEntityService<TPersistentEntity>
            : IPersistentEntityService<TPersistentEntity, string>
        where TPersistentEntity : IPersistentEntity<string>
    {
    }
