    ServicePointManager.CheckCertificateRevocationList = false;
    ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Ssl3 | System.Net.SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
    ServicePointManager.ServerCertificateValidationCallback += (senderj, cert, chain, sslPolicyErrors) => true;
    
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.3m.com");
    
    request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
    request.Timeout = 5000;
    request.KeepAlive = false;
    request.AllowAutoRedirect = true;
    request.Accept = "text/html, application/xhtml+xml, application/xml; q=0.9, image/webp, */*; q=0.8";
    request.Headers["Accept-Language"] = "en-GB,en-US;q=0.7,en;q=0.3";
    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    Stream dataStream = response.GetResponseStream();
    StreamReader reader = new StreamReader(dataStream);
    string responseFromServer = reader.ReadToEnd();
