    internal class DocumentDBRepositoryFactory<T>
    {
        public IDocumentDBRepository<T> Create(string databaseName)
            => return new DocumentDBRepository(databaseName);
    }
