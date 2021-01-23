    // Initialise the WebRequest.
    WebRequest webRequest = WebRequest.Create("[your URI here]");
    // Return the response. 
    WebResponse webResponse = webRequest.GetResponse();
    // Close the response to free resources.
    webResponse.Close();
    
    if (webResponse.ContentLength > 0) // May have to catch an exception here instead
    {
        Process.Start("iisreset.exe", "/reset"); // Or whatever arg you want
    
    }
