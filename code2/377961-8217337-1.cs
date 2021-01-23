    public class VersionService : IVersionService
    {
        string _versionTag;
        public VersionService()
        {
            _versionTag = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            _versionTag = _versionTag.Replace('.', '-');
        }
        #region IVersionedContentService Members
    
        public string GetVersionTag()
        {
            return _versionTag;
        }
    
        #endregion
    }
