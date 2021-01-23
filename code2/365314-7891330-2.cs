        class Program
	    {
	         	static void Main(string[] args)
		        {
			       string str = @"{""workspace"": {
                      ""name"":""Dallas"",
                      ""dataStores"":""http://.....:8080/geoserver/rest/workspaces/Dallas/datastores.json"",
                      ""coverageStores"":""http://.....:8080/geoserver/rest/workspaces/Dallas/coveragestores.json      "",
                      ""wmsStores"":""http://....:8080/geoserver/rest/workspaces/Dallas/wmsstores.json""}}";
                     var obj = JsonConvert.DeserializeObject<objSON>(str);
			
		}
		
	}
	public class workspace
	{
		public string name { get; set; }
		public string dataStores { get; set; }
		public string coverageStores { get; set; }
		public string wmsStores { get; set; }
	}
	public class objSON
	{
		public workspace workspace { get; set; }
	}
    
