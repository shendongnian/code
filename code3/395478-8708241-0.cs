    Try this:
    
    string postData =  Uri.EscapeDataString("test+PlusSigns");
    StreamWriter writer = new StreamWriter(request.GetRequestStream());
    writer.Write(postData);
    writer.Close();
    
    HttpWebResponse Response = (HttpWebResponse)request.GetResponse();
    Response.Close();
