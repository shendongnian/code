    using System;
    using Newtonsoft.Json.Linq;
					
    public class Program
    {
    	public static void Main()
    	{
    	    string jsonstring = "{\"status\":true,\"message\":\"connected\"}";
    		 JObject json = JObject.Parse(jsonstring); //this is thr string     
    		string statusValue = (string)json["status"];
    		MessageBox.Show("Status :"+statusValue);
    	}
    }
