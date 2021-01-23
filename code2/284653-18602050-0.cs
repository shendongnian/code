    using System;
    using System.Net;
    
    class Program
    {
    	public static void Main ()
    	{
    		foreach (var ip in Dns.GetHostAddresses (Dns.GetHostName ())) 
    		{
    			Console.WriteLine ("Request from: " + ip);
    			var request = (HttpWebRequest)HttpWebRequest.Create ("http://ns1.vianett.no/");
    			request.ServicePoint.BindIPEndPointDelegate = delegate {
    				return new IPEndPoint (ip, 0);
    			};
    			var response = (HttpWebResponse)request.GetResponse ();
    			Console.WriteLine ("Actual IP: " + response.GetResponseHeader ("X-YourIP"));
    			response.Close ();
    		}
    	}
    }
