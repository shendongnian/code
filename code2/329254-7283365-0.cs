    using System;
    using System.Net;
    using System.IO;
    
    ...
    
    string url = "http://localhost:8080/geoserver/rest/workspaces";
    WebRequest request = WebRequest.Create(url);
    
    request.ContentType = "text/xml";
    request.Method = "POST";
    request.Credentials = new NetworkCredential("admin", "geoserver");
    
    byte[] buffer = Encoding.GetEncoding("UTF-8").GetBytes("<workspace><name>my_workspace</name></workspace>");
    Stream reqstr = request.GetRequestStream();
    reqstr.Write(buffer, 0, buffer.Length);
    reqstr.Close();
    
    WebResponse response = request.GetResponse();
    
    ...
