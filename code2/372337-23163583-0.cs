    var url = string.Format("http://ravendb-server:8080/databases/{0}/docs/{1}", databaseName, docId);
    var webRequest = System.Net.HttpWebRequest.CreateHttp(url);
    webRequest.Method = "PUT";
    webRequest.ContentType = "application/json";
    webRequest.Headers["Raven-Entity-Name"] = entityName;
    var stream = webRequest.GetRequestStream();
    using (var writer = new System.IO.StreamWriter(webRequest.GetRequestStream()))
    {
        writer.Write(json);
    }
    var webResponse = webRequest.GetResponse();
    webResponse.Close();
