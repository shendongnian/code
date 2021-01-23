    var r = new { ServiceName = "AccountService.svc", Type = "POST", MethodName = "AjaxFindCompany",  
        Data = "{\"AccountNumber\":null,\"Address\":{\"City\":\"Pittsburgh\",\"Country\":null,\"State\":\"PA\",\"Street1\":\"1001 Liberty Ave\",\"ZipCode\":\"15222\"},\"BusinessName\":\"AUto\"}" }; 
 
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Format("{0}/{1}/{2}", "http://localhost:2749", r.ServiceName, r.MethodName)); 
    request.Method = r.Type;
    Stream reqStream = request.GetRequestStream();
    byte[] reqBytes = Encoding.UTF8.GetBytes(r.Data as string);
    reqStream.Write(reqBytes, 0, reqBytes.Length);
    reqStream.Close();
    HttpWebResponse response = (HttpWebResponse)request.GetResponse(); 
    StreamReader contentReader = new StreamReader(response.GetResponseStream()); 
    Response.ContentType = response.ContentType; 
    Response.Write(contentReader.ReadToEnd()); 
