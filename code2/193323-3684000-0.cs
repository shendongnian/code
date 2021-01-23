    string sURL = ".....";
    // Create a request for the URL. 
    WebRequest oRequest = WebRequest.Create(sUrl);
    // Get the response.
    WebResponse oResponse = oRequest.GetResponse();
    // Get the stream containing content returned by the server.
    Stream oDataStream = oResponse.GetResponseStream();
    // Open the stream using a StreamReader for easy access.
    StreamReader oReader = new StreamReader(oDataStream, System.Text.Encoding.Default);
    // Read the content.
    string sXML = oReader.ReadToEnd();
    // Convert string to XML
    XDocument oFeed = XDocument.Parse(sXML);
