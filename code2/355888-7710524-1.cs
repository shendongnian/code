    [Given(@"Config\.IsServiceActive returns false")]
    public void GivenConfig_IsServiceActiveReturnsFalse()
    {
        var settings = new DispatchSettings
        {
            ServiceIsActive = false,
            DispatchProcessBatchSize = 100,
            UpdatedBy = "Unit Test"    
        };
        DispatchConfiguration.ConfigureStructureMap(ObjectFactory.Container, settings);
    }
