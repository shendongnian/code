    using System;
    using System.Net;
    
    class Program
    {
    	public static void Main ()
    	{
    		// TODO: Put your ip addresses in this list
    		var ips = new IPAddress[]
    		{
    			IPAddress.Parse("10.0.0.3"),
    			IPAddress.Parse("192.168.1.7")
    		};
    
    		foreach (var ip in ips)
    		{
    			try
    			{
    				Console.WriteLine("Request from: " + ip);
    				var request = (HttpWebRequest)HttpWebRequest.Create("http://ns1.vianett.no/");
    				request.ServicePoint.BindIPEndPointDelegate = delegate
    				{
    					return new IPEndPoint(ip, 0);
    				};
    				var response = (HttpWebResponse)request.GetResponse();
    				Console.WriteLine("Actual IP: " + response.GetResponseHeader("X-YourIP"));
    				response.Close();
    			}
    			catch (Exception ex)
    			{
    				Console.WriteLine(ex.Message);
    			}
    		}
    	}
    }
