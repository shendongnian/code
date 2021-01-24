    container.RegisterType<FileSystemPricerStagingDirectorySettings>(new InjectionConstructor(ConfigurationManager.AppSettings["PricerStagingDirectory"]));
    
    container.RegisterType<IPricerStagingRepository, FileSystemPricerStagingRepository>();
    
    public FileSystemPricerStagingRepository(FileSystemPricerStagingDirectorySettings pricerStagingDirectorySettings)
    {
        // now I can get what I need from pricerStagingDirectorySettings
    }
