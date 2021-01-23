    // User object serialized to XML
    XElement data = new XElement("User",
      new XElement("UserName", UserName),
      new XElement("Password", Password)
    );
    MemoryStream dataSream = new MemoryStream();
    data.Save(dataStream);
    
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(YourServiceUrl);
    request.Method = "POST";
    request.ContentType = "application/xml";
    // You need to know length and it has to be set before you access request stream
    request.ContentLength = dataStream.Length; 
    using (Stream requestStream = request.GetRequestStream())
    {
      dataStream.CopyTo(requestStream);   
      requestStream.Close();
    } 
    
    HttpWebResponse response = request.GetResponse();
    if (response.Status == HttpStatusCode.Unauthorized)
    {
      ...
    }
    else
    {
      ...
    }
    response.Close();
