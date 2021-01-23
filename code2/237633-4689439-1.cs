    // build URL up at runtime
    string apiKey = ConfigurationManager.AppSettings["geoApiKey"];
    string url = String.Format(ConfigurationManager.AppSettings["geoApiUrl"], apiKey, ip);
    WebRequest request = WebRequest.Create(url);
    try
    {
        WebResponse response = request.GetResponse();
        using (var sr = new System.IO.StreamReader(response.GetResponseStream()))
        {
            XDocument xmlDoc = new XDocument();
            try
            {
                xmlDoc = XDocument.Parse(sr.ReadToEnd());
                string status = xmlDoc.Root.Element("Status").Value;
                Console.WriteLine("Response status: {0}", status);
                if (status == "OK")
                { 
                    // if the status is OK it's normally safe to assume the required elements
                    // are there. However, if you want to be safe you can always check the element
                    // exists before retrieving the value
                    Console.WriteLine(xmlDoc.Root.Element("CountryCode").Value);
                    Console.WriteLine(xmlDoc.Root.Element("CountryName").Value);
                    ...
                }                
            }
            catch (Exception)
            {
                // handle if necessary
            }   
        }
    }
    catch (WebException)
    {
        // handle if necessary    
    }
