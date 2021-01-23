    public static class DispatchConfiguration
    {
        public static void ConfigureStructureMap(IContainer container, IDispatchConfiguration dispatchConfig)
        {
            DispatchProcessBatchSize = dispatchConfig.DispatchProcessBatchSize;
            ServiceIsActive = dispatchConfig.ServiceIsActive;
            ...
        }
