    Uri uri = new Uri(url);
    WebRequest webRequest = WebRequest.Create(uri);
    webRequest.EnableSsl;
    ServicePointManager.ServerCertificateValidationCallback = (s, cert, chain, ssl) => true;
    WebResponse webResponse = webRequest.GetResponse();
    ReadFrom(webResponse.GetResponseStream());
