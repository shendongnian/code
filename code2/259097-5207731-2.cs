    var uri = new Uri("https:/example.com/auth");
    var request = (HttpWebRequest)WebRequest.Create(uri);
    request.Accept = "application/xml";
    // authentication
    var cache = new CredentialCache();
    cache.Add(uri, "Basic", new NetworkCredential("user", "secret"));
    request.Credentials = cache;
    ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
    // response.
    var response = (HttpWebResponse)request.GetResponse();
