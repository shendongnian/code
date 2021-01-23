    public sealed class CompanyDetailProvider : ICompanyDetailProvider
    {
        private readonly IFilePathProvider _filePathProvider;
        private readonly IEntityReader _entityReader;
        public CompanyDetailProvider(IFilePathProvider filePathProvider, IEntityReader entityReader)
        {
            _filePathProvider = filePathProvider;
            _entityReader = entityReader;
        }
        public IEnumerable<CompanyDetail> GetCompanyDetailsForDate(DateTime date)
        {
            var path = _filePathProvider.GetCompanyDetailsFilePathForDate(date);
            return _entityReader.ReadEntities<CompanyDetail>(path);
        }
    }
