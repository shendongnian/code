    void Main()
    {
    	string jsonStorageProducts = @"
    {
       ""Result"": ""Success"",
       ""BodyText"": 
      {
      ""products"": 
    {
      ""totalProducts"": 510,
      ""recordsPerPage"": 10,
      ""page"": 1,
      ""totalPages"": 51,
      ""vendors"": [
        {
          ""vendorId"": ""397"",
          ""vendorName"": ""Microsoft"",
          ""listings"": [
            {
              ""listingName"": ""Office 365 Enterprise"",
              ""skus"": [
                {
                  ""sku"": ""SK10228"",
                  ""skuName"": ""Microsoft 365 E5 without Audio Conferencing"",
                  ""description"": ""Pending"",
                  ""zeroValueSku"": ""t"",
                  ""manufacturerPartNumber"": ""db5e0b1c9cc3459c9d08c61993959fd3"",
                  ""article"": ""4090153"",
                  ""vendorMapId"": ""db5e0b1c-9cc3-459c-9d08-c61993959fd3"",
                  ""billingType"": ""Monthly"",
                  ""productType"": ""SaaS"",
                  ""qtyMin"": ""1"",
                  ""qtyMax"": """",
                  ""addOns"": [
                    {
                      ""sku"": ""SK8265"",
                      ""skuName"": ""Audio Conferencing"",
                      ""description"": ""For businesses that need to enable users to dial-in a number to join Skype meetings, or dial-out to bring participants into the meeting. There are base pre-requisites required to purchase this offering."",
                      ""zeroValueSku"": ""t"",
                      ""qtyMin"": ""1"",
                      ""qtyMax"": """",
                      ""vendorMapId"": ""c94271d8-b431-4a25-a3c5-a57737a1c909"",
                      ""manufacturerPartNumber"": ""c94271d8b4314a25a3c5a57737a1c909"",
                      ""article"": ""3873033""
                    },
                    {
                      ""sku"": ""SK8772"",
                      ""skuName"": ""Domestic and International Calling Plan"",
                      ""description"": ""For Businesses that need to enable online users to place or receive Domestic and International calls through the Public Switched Telephone Network (PSTN). There are base pre-requisites required to purchase this offering."",
                      ""zeroValueSku"": ""t"",
                      ""qtyMin"": ""1"",
                      ""qtyMax"": """",
                      ""vendorMapId"": ""ded34535-507f-4246-8370-f9180318c537"",
                      ""manufacturerPartNumber"": ""ded34535507f42468370f9180318c537"",
                      ""article"": ""3968760""
                    }
                  ]
                }
              ]
            }
          ]
        }
      ]
    }
    },
      ""Key"": 3298012
    }
    ";
    	RootObject skuIdName = JsonConvert.DeserializeObject<RootObject>(jsonStorageProducts);
    	var productSku = skuIdName.BodyText.products.vendors
    	 .SelectMany(x =>x.listings
    	 .SelectMany(l => l.skus
    	 .SelectMany(s => s.addOns
    	 .Select(o => new { 
    	 	SKU = o.sku, 
    		Name = o.skuName }))));
    
    	foreach (var sku in productSku)
    	{
    		Console.WriteLine($"SKU: {sku.SKU}, Name: {sku.Name}");
    	}
    }
    
    
    public class AddOn
    {
    	[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
    	public string Id { get; set; }
    	public string sku { get; set; }
    	public string skuName { get; set; }
    	public string description { get; set; }
    	public string zeroValueSku { get; set; }
    	public string qtyMin { get; set; }
    	public string qtyMax { get; set; }
    	public string vendorMapId { get; set; }
    	public string manufacturerPartNumber { get; set; }
    	public string article { get; set; }
    	public override string ToString()
    	{
    		return JsonConvert.SerializeObject(this);
    	}
    }
    
    public class Sku
    {
    	public string sku { get; set; }
    	public string skuName { get; set; }
    	public string description { get; set; }
    	public string zeroValueSku { get; set; }
    	public string manufacturerPartNumber { get; set; }
    	public string article { get; set; }
    	public string vendorMapId { get; set; }
    	public string billingType { get; set; }
    	public string productType { get; set; }
    	public string qtyMin { get; set; }
    	public string qtyMax { get; set; }
    	public List<AddOn> addOns { get; set; }
    	public List<string> datacenterLocations { get; set; }
    	public List<AddOn2> add { get; set; }
    }
    
    public class AddOn2
    {
    	public string sku { get; set; }
    	public string skuName { get; set; }
    	public string description { get; set; }
    	public string zeroValueSku { get; set; }
    	public string qtyMin { get; set; }
    	public string qtyMax { get; set; }
    	public string manufacturerPartNumber { get; set; }
    	public string article { get; set; }
    
    	public List<Sku> sk { get; set; }
    }
    
    public class Listing
    {
    	public string listingName { get; set; }
    	public List<Sku> skus { get; set; }
    	public List<AddOn2> addOns { get; set; }
    
    	//new
    	//public List<AddOn2> addon2s { get; set; }
    }
    
    public class Vendor
    {
    	public string vendorId { get; set; }
    	public string vendorName { get; set; }//microsoft
    	public List<Listing> listings { get; set; }
    
    	// public List<Sku> skus { get; set; }
    }
    
    public class Products
    {
    	public int totalProducts { get; set; }
    	public int recordsPerPage { get; set; }
    	public int page { get; set; }
    	public int totalPages { get; set; }
    	public List<Vendor> vendors { get; set; }
    }
    
    public class BodyText
    {
    	public Products products { get; set; }
    }
    
    public class RootObject
    {
    	public string Result { get; set; }
    	public BodyText BodyText { get; set; }
    	public int Key { get; set; }
    }
