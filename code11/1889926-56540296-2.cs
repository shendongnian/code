    XDocument xDocument = XDocument.Parse("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n<note>\r\n  <to>Tove</to>\r\n  <from>Jani</from>\r\n  <heading>Reminder</heading>\r\n  <body>Don't forget me this weekend!</body>\r\n</note>");
    
    string xmlRequestBody = xDocument.ToString();
    // Create a New HttpClient object and dispose it when done, so the app doesn't leak resources
    using (HttpClient client = new HttpClient())
    {
        // Call asynchronous network methods in a try/catch block to handle exceptions
        try	
        {
            HttpResponseMessage response = await client.PostAsync("your_external_url", new StringContent(xmlRequestBody, Encoding.UTF8, "text/xml")));
            response.EnsureSuccessStatusCode();
            // responseBody will contain the response XML document (hopefully!)
            string responseBody = await response.Content.ReadAsStringAsync();
    
            // parse the string into an XDocument
            XDocument responseDocument = XDocument.Parse(responseBody);
            Console.WriteLine(responseBody);
        }  
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");	
            Console.WriteLine("Message :{0} ",e.Message);
        }
    }
