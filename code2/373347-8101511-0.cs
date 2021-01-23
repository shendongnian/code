    public Logging()
    {
        // Resolve the default LogWriter object from the container.
        // The actual concrete type is determined by the configuration settings.
        defaultWriter = new LogWriterFactory().Create();
    }
