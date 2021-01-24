    public class BaseRequest
    {
        public string messageId { get; set; }
        public string timestamp { get; set; }
        public string updatedAtMin { get; set; }
        public int page { get; set; }
    
        public BaseRequest(DateTime updatedAtMin, int page)
        {
            this.messageId = Guid.NewGuid().ToString();
            this.timestamp = DateTime.UtcNow.ToString("o");
            this.updatedAtMin = updatedAtMin.ToString("o");
            this.page = page;
        }
    		
    	public BaseRequest() {
    	}
    }
    	
    public class CaseRequest : BaseRequest
    {
        public bool extraParameter { get; set; }
    
        public CaseRequest(bool extraParameter) : base()
        {
            this.extraParameter = extraParameter;
        }
    }
