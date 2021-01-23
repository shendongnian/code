        HttpWebRequest myWebRequest=(HttpWebRequest)WebRequest.Create("http://www.microsoft.com");
        
        // Obtain the 'Proxy' of the  Default browser.  
        IWebProxy proxy = myWebRequest.Proxy;
        // Print the Proxy Url to the console.
        if (proxy != null)
        {
            Console.WriteLine("Proxy: {0}", proxy.GetProxy(myWebRequest.RequestUri));
        } 
        else
        {
            Console.WriteLine("Proxy is null; no proxy will be used");
        }
