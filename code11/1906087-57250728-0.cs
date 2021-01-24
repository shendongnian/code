    using System;
    using Newtonsoft.Json;
    
    using System.Net;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var client = new WebClient();
    		var url = "https://www.reddit.com/r/" + "memes" + "/new.json?sort=new&limit=1";
    		var json =  client.DownloadString(url);
    		dynamic output = JsonConvert.DeserializeObject<dynamic>(json);
    		Console.WriteLine(output.data.children[0].data.title);
    	}
    }
