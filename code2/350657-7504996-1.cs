    public class License
    {
    	public string licName{ get; set; }
    	public string frn { get; set; }
    	public string callsign { get; set;}
    	public string categoryDesc { get; set; }
    	public string serviceDesc { get; set; }
    	public string statusDesc { get; set; }
    	public string expiredDate { get; set; } //JSON dates and C# Dates are very finicky
    	public string licenseID { get; set; }
    	public string licDetailURL { get; set; }
    }
    
    public class Licenses
    {
    	public int page {get; set;}
    	public int rowPerPage {get; set;}
    	public int totalRows {get; set;}
    	public string lastUpdate {get; set;}
    	public List<License> License {get; set;}
    }
    public ActionResult Licenses()
    {
		var result = string.Empty;
		var url = "http://data.fcc.gov/api/license-view/basicSearch/getLicenses?searchValue=Verizon+Wireless&format=jsonp&jsonCallback=?";
		var webRequest = WebRequest.Create(url);
		webRequest.Timeout = 2000;
		using (var response = webRequest.GetResponse() as HttpWebResponse)
		{
			if (response.StatusCode == HttpStatusCode.OK)
			{
				var receiveStream = response.GetResponseStream();
				if (receiveStream != null)
				{
					var stream = new StreamReader(receiveStream);
					result = stream.ReadToEnd();
				}
			}
		}
                
       Licenses licenses;
 
		if(result != null)
		{
			 JavaScriptSerializer serializer = new JavaScriptSerializer();
			 licenses = serializer.Deserialize<Licenses>(result);
		}
		return View(licenses.License);
    }
