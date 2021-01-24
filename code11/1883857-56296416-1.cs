    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using System.Net;
    using System.IO;
    using System.Diagnostics;
    					
    public class Brand
    {
        public string name { get; set; }
    }
    
    public class Link
    {
        public string href { get; set; }
    }
    
    public class Price
    {
        public double current { get; set; }
    }
    
    public class RootObject
    {
        public Brand brand { get; set; }
        public string href { get; set; }
        public List<Link> links { get; set; }
        public List<string> mpns { get; set; }
        public string name { get; set; }
        public Price price { get; set; }
        public string productId { get; set; }
    }
    
    public class Program
    {
    	public static void Main()
    	{
    		string API = "https://www.verkkokauppa.com/resp-api/product?pids=552952";
    		HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(API);
    		request.Method = "GET";
    		string result = "";
    		using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
    		{
    			Stream dataStream = response.GetResponseStream();
    			StreamReader reader = new StreamReader(dataStream);
    			result = reader.ReadToEnd();
    			reader.Close();
    			dataStream.Close();
    		}
    
    		var jsonresult = JsonConvert.DeserializeObject<List<RootObject>>(result);
    
    		foreach (RootObject p in jsonresult)
    		{
    
    			Debug.WriteLine(p.brand.name);
    		}
    	}
    }
