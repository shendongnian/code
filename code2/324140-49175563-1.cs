    public class WizardStepAttribute : Attribute, IMetadataAware
    {
        public string Name;
        public void OnMetadataCreated(ModelMetadata metadata)
        {
            if (!metadata.AdditionalValues.ContainsKey("WizardStep"))
            {
                metadata.AdditionalValues.Add("WizardStep", Name);
            }
        }
    }
