    public class SoapObject
    {
    	[JsonProperty("soap12:Envelope")]
    	public SoapData	Envelope { get; set; }
    }
    
    public class SoapData
    {
    	[JsonProperty("soap12:Body")]
    	public SoapBody Body { get; set; }
    }
    
    public class SoapBody
    {
    	public ProcessRequestResponse ProcessRequestResponse { get; set; }
    }
    
    public class ProcessRequestResponse
    {
    	public ProcessRequestResult ProcessRequestResult { get; set; }
    }
    
    public class ProcessRequestResult
    {
    	public string StatusCode { get; set; }
    	public string Success { get; set; }
    }
