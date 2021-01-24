    public class BALServices
    {
        private readonly DbSettings _dbSettings;
        public BALServices(IOptions<DbSettings> dbSettings)
        {
            _dbSettings = dbSettings.Value;
        }
    }
