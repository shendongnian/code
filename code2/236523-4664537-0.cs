    public class SampleTenant : AbstractApplicationTenant
    {
        public SampleTenant(IFeatureRegistry enabledFeatures)
        {
            ApplicationName = "Sample 1";
    
            EnabledFeatures = enabledFeatures;
        }
    }
