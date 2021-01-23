    // Variables.
    System.Net.HttpWebRequest Request;
    System.Net.WebResponse Response;
    System.Net.CredentialCache MyCredentialCache;
    string strRootURI = "http://servername/Exchange/email@test.com/Inbox/";
    string strUserName = "userName";
    string strPassword = "password";
    string strDomain = "domain";
    string strQuery = "";
    byte[] bytes = null;
    System.IO.Stream RequestStream = null;
    System.IO.Stream ResponseStream = null;
    XmlDocument ResponseXmlDoc = null;
    XmlNodeList DisplayNameNodes = null;
    XmlNodeList BodyNodes = null;
    try
    {
        //Build the SQL query.
        strQuery = "<?xml version=\"1.0\"?><D:searchrequest xmlns:D = \"DAV:\" >"
                + "<D:sql>SELECT \"DAV:displayname\", \"http://schemas.microsoft.com/mapi/proptag/x1000001e\" FROM \"" + strRootURI + "\""
                + "WHERE \"DAV:ishidden\" = false AND \"DAV:isfolder\" = false"
                + "</D:sql></D:searchrequest>";
    // Create a new CredentialCache object and fill it with the network
    // credentials required to access the server.
    MyCredentialCache = new System.Net.CredentialCache();
    MyCredentialCache.Add(new System.Uri(strRootURI),
       "NTLM",
       new System.Net.NetworkCredential(strUserName, strPassword, strDomain)
       );
    // Create the HttpWebRequest object.
    Request = (System.Net.HttpWebRequest)HttpWebRequest.Create(strRootURI);
    // Add the network credentials to the request.
    Request.Credentials = MyCredentialCache;
    // Specify the method.
    Request.Method = "SEARCH";
    // Encode the body using UTF-8.
    bytes = Encoding.UTF8.GetBytes((string)strQuery);
    // Set the content header length.  This must be
    // done before writing data to the request stream.
    Request.ContentLength = bytes.Length;
    // Get a reference to the request stream.
    RequestStream = Request.GetRequestStream();
    // Write the SQL query to the request stream.
    RequestStream.Write(bytes, 0, bytes.Length);
    // Close the Stream object to release the connection
    // for further use.
    RequestStream.Close();
    // Set the content type header.
    Request.ContentType = "text/xml";
    // Send the SEARCH method request and get the
    // response from the server.
    Response = (HttpWebResponse)Request.GetResponse();
    // Get the XML response stream.
    ResponseStream = Response.GetResponseStream();
    // Create the XmlDocument object from the XML response stream.
    ResponseXmlDoc = new XmlDocument();
    ResponseXmlDoc.Load(ResponseStream);
    // Build a list of the DAV:href XML nodes, corresponding to the folders
    // in the mailbox.  The DAV: namespace is typically assgigned the a:
    // prefix in the XML response body.
    DisplayNameNodes = ResponseXmlDoc.GetElementsByTagName("a:displayname");
    BodyNodes = ResponseXmlDoc.GetElementsByTagName("d:x1000001e");
    DataTable emails = new DataTable();
    emails.Columns.Add("Subject");
    emails.Columns.Add("Body");
    if (DisplayNameNodes.Count > 0)
    {
        Console.WriteLine("Non-folder item display names...");
        // Loop through the display name nodes.
        for (int i = 0; i < DisplayNameNodes.Count; i++)
        {
            DataRow row = emails.NewRow();
            row[0] = DisplayNameNodes[i].InnerText.ToString().Trim();
            row[1] = BodyNodes[i].InnerText.ToString().Trim();
            emails.Rows.Add(row);
        }
    }
    else
    {
        Console.WriteLine("No non-folder items found...");
    }
    foreach (DataRow row in emails.Rows)
    {
        Console.WriteLine("Subject: {0}", row["Subject"]);
        Console.WriteLine("Body: {0}", row["Body"]);
        Console.WriteLine("-------------------------------------------------------------------");
    }
    // Clean up.
    ResponseStream.Close();
    Response.Close();
    }
    catch (Exception ex)
    {
        // Catch any exceptions. Any error codes from the SEARCH
        // method request on the server will be caught here, also.
        Console.WriteLine(ex.Message);
    }
