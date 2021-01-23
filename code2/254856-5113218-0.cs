    public class YourWcfService
    {
        ICacheManager _cacheManager = null;
        public YourWcfService()
        {
            _cacheManager = EnterpriseLibraryContainer.Current.GetInstance<ICacheManager>("Cache Manager");
        }
