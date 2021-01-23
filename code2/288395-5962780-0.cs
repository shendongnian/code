    /// <summary>
    /// Validate the user credentials held as member variables
    /// </summary>
    /// <returns>True if the user credentials are valid, else false</returns>
    public bool ValidateUser()
    {
        bool valid = false;
        try
        {
            // Create the XML to be passed as the request
            XElement root = BuildRequestXML("LOGON");
            // Add the action to the service address
            Uri serviceReq = new Uri(m_ServiceAddress + "?obj=LOGON");
            // Create the client for the request to be sent from
            using (HttpClient client = new HttpClient())
            {
                // Initalise a response object
                HttpResponseMessage response = null;
                #if DEBUG
                // Force the request to use fiddler
                client.TransportSettings.Proxy = new WebProxy("127.0.0.1", 8888);
                #endif
                // Create a content object for the request
                HttpContent content = HttpContent.Create(root.ToString(), Encoding.UTF8, "text/xml");
                // Make the request and retrieve the response
                response = client.Post(serviceReq, content);
                // Throw an exception if the response is not a 200 level response
                response.EnsureStatusIsSuccessful();
                // Retrieve the content of the response for processing
                response.Content.LoadIntoBuffer();
                // TODO: parse the response string for the required data
                XElement retElement = response.Content.ReadAsXElement();
            }
        }
        catch (Exception ex)
        {
            Log.WriteLine(Category.Serious, "Unable to validate the user credentials", ex);
            valid = false;
            m_uid = string.Empty;
        }
        return valid;
    }
