    using System.Net;
    using System.IO;
    ...
    HttpWebRequest req = WebRequest.Create("http://apiurl.com?args=go.here");
    req.UserAgent = "The name of my program";
    WebResponse resp = req.GetResponse();
    string responseData = null;
    using(TextReader reader = new StreamReader(resp.GetResponseStream())) {
        responseData = reader.ReadToEnd();
    }
    //do whatever with responseData
