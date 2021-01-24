    public class UploadSessionResponse
    {
        public string odatacontext { get; set; }
        public DateTime expirationDateTime { get; set; }
        public string[] nextExpectedRanges { get; set; }
        public string uploadUrl { get; set; }
    }
