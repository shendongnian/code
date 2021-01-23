    public MyCustomPlugin(PluginId id, SettingsRepostiory settingsRepository)
    {
    	_id = id;
    	_settingsRepository = settings;
    }
    
    public void SomePluginMethod()
    {
    	PluginSettings setting = settingsRepository.Settings.WithId(_id);
    	//...
    }
