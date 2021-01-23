    using System.Net;
    using System.IO;
    using System.Text;
    private string SendRequest(string xml, string url)
    {
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
        byte[] requestBytes = Encoding.ASCII.GetBytes(xml);
        req.Method = "POST";
        req.ContentType = "text/xml;charset=utf-8";
        req.ContentLength = requestBytes.Length;
        Stream requestStream = req.GetRequestStream();
        requestStream.Write(requestBytes, 0, requestBytes.Length);
        requestStream.Close();
        HttpWebResponse res = (HttpWebResponse)req.GetResponse();
        StreamReader sr = new StreamReader(res.GetResponseStream(), Encoding.Default);
        string response = sr.ReadToEnd();
        sr.Close();
        res.Close();
        return response; 
    }
