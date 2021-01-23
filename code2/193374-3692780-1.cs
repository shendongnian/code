    public sealed class EntityReader : IEntityReader
    {
        private readonly IDataReaderFactory _dataReaderFactory;
        public EntityReader(IDataReaderFactory dataReaderFactory)
        {
            _dataReaderFactory = dataReaderFactory;
        }
        public IEnumerable<T> ReadEntities<T>(string path)
        {
            Func<IDataReader> sourceProvider =
                () => _dataReaderFactory.CreateReader(DataFileType.FlatFile, path);
            return new Hydrator<T>(sourceProvider);
        }
    }
