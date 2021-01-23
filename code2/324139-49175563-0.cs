    public class WizzardStepAttribute : Attribute, IMetadataAware
    {
        public string Name;
        public void OnMetadataCreated(ModelMetadata metadata)
        {
            if (!metadata.AdditionalValues.ContainsKey("WizzardStep"))
            {
                metadata.AdditionalValues.Add("WizzardStep", Name);
            }
        }
    }
