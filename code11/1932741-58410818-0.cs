    public class FilteringRequestModel
    {
        public FilteringRequestModel()
        {
        }
    
        public void Initialize(IOptions<FilteringRequestSettings> settings)
        {
            if (string.IsNullOrEmpty(this.Type))
            {
                this.Type = settings.Value.Type;
            }
        }
    
        public string Type { get; set; }
    }
