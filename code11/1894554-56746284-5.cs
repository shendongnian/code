        private readonly YourSettings _settings;
        public YourController(IOptions<YourSettings> settings)
        {
            _spDataRepo = spDataRepo;
            _settings = settings.Value;
            DoStuffWithSettings();
        }
        public void DoStuffWithSettings()
        {
            Debug.Print($"Hey the logs are here: {_settings.LogPath}");
        }
