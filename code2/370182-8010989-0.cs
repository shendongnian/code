    public class StepTitleAttribute : Attribute, IMetadataAware
    {
        private readonly string _title;
        public StepTitleAttribute(string title)
        {
            _title = title;
        }
        public void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.AdditionalValues["title"] = _title;
        }
    }
