    public class OptionsValidator
    {
        private readonly IOptions<UploadConfig> uploadOptions;
        public OptionsValidator(IOptions<UploadConfig> uploadOptions)
        {
            _uploadOptions = uploadOptions;
        }
        public void Validate()
        {
            if (string.IsNullOrEmpty(_uploadOptions.Value.Config1))
                throw Exception("Upload options are not configured properly");
        }
    }
