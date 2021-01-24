    public class CustomResolver : IValueResolver<Configuration, ConfigurationDto, string>
    {
        private readonly IFileStorage fileStorage;
        public CustomResolver(IFileStorage fileStorage)
        {
            _fileStorage= fileStorage;
        }
	    public int Resolve(Configuration source, ConfigurationDto destination, string member, ResolutionContext context)
	    {
            return _fileStorage.GetShortTemporaryLink(source.FilePath);
	    }
    }
