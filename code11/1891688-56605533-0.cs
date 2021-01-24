    WebRequest req = WebRequest.Create(url);
    req.AuthenticationLevel = System.Net.Security.AuthenticationLevel.MutualAuthRequested;
    req.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
    HttpWebResponse myHttpWebResponse = (HttpWebResponse)req.GetResponse();
    if (myHttpWebResponse.StatusCode == HttpStatusCode.OK)
    {
    Console.WriteLine("\r\nResponse Status Code is OK and StatusDescription is: {0}", myHttpWebResponse.StatusDescription);
    }
    // Releases the resources of the response.
    myHttpWebResponse.Close();
