    string urlOfService = "http://somewhere.com/RestService.svc/EchoWithPost";
    string postData = "<EchoWithPost xmlns=\"http://tempuri.org/\"><message>Vito</message></EchoWithPost>";
    byte[] byteArray = Encoding.UTF8.GetBytes(postData);
    WebRequest request = WebRequest.Create(urlOfService);
    request.Method = "POST";
    request.ContentType = "application/xml;";
    request.ContentLength = byteArray.Length;
    Stream dataStream = request.GetRequestStream();
    dataStream.Write(byteArray, 0, byteArray.Length);
    dataStream.Close();
    WebResponse webResponse = request.GetResponse();
    // Output raw string result
    string rawStringResult = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();
    HttpContext.Current.Response.Write("\r\n" + rawStringResult);
