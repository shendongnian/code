    private static T MapDataReaderToEntity<T>(IDataReader reader)
        where T : IEntity, new()
    {
        T entity = new T(); // typeof(T) would return the System.Type, not an instance!
        entity.Code = SqlPersistence.GetString(reader, "Code");
        entity.Name = SqlPersistence.GetString(reader, "Name");
        return entity;
    }
