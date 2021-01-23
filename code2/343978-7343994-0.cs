    using System;
    using System.Net;
    
    class Program
    {
        static void Main()
        {
    	// Create web client.
    	WebClient client = new WebClient();
    
    	// Download string.
    	string ip = client.DownloadString("http://showip.codebrainz.ca/");
    
    	// Write ip.
    	Console.WriteLine(ip);
        }
    }
