    public class Product
    {
    	public string PROD { get; set; }
       
    	//Department Number
    	[JsonProperty("DPID")]
    	public int DPID { get; set; }
    	
    
    	//Sub Department Number
    	[JsonProperty("SDID")]
    	public int SDID { get; set; }
    
    	//Category Number
    	[JsonProperty("CGID")]
    	public int CGID { get; set; }
    
    	//Sub Category Number
    	[JsonProperty("SCID")]
    	public int SCID { get; set; }
    
    	//Product Description
    	[JsonProperty("PDSC")]
    	public string PDSC { get; set; }
       
    
    	//Product Brand
    	[JsonProperty("PBRN")]
    	public string PBRN { get; set; }
       
    
    	//Season Code
    	[JsonProperty("SESN")]
    	public string SESN { get; set; }
    
    	//Issue Quantity
    	[JsonProperty("IQTY")]
    	public string IQTY { get; set; }
    
    
    	//Currency Code
    	[JsonProperty("CURR")]
    	public string CURR { get; set; }
       
    	//Selling Price
    	[JsonProperty("SELL")]
    	public decimal SELL { get; set; }
    
    	//Product SKU Code
    	[JsonProperty("PSKU")]
    	public string PSKU { get; set; }
    
    	//Product Size
    	[JsonProperty("PSZE")]
    	public string PSZE { get; set; }
       
    	//Product Colour
    	[JsonProperty("PCOL")]
    	public string PCOL { get; set; }
    
    	//Pre-pack Code
    	[JsonProperty("PPCD")]
    	public string PPCD { get; set; }
    	//Image URL
    	public string IURL { get; set; }
    
    	[JsonProperty("DPDS")]
    	public string DPDS { get; set; }
    }
