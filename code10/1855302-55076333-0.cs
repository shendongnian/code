    public HelloWorldController(IOptions<UploadConfig> config)
    {
        if (string.IsNullOrEmpty(config.Value.Config1))
            throw ArgumentException("Config1 is not configured properly");
    }
