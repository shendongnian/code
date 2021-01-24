    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
    request.ServicePoint.Expect100Continue = false;
    request.Method = "POST";
    request.ContentType = MimeMapping.GetMimeMapping(FilePath);
    using (FileStream fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
    using(Stream requestStream = request.GetRequestStream())
    {
        byte[] buffer = new byte[1024 * 4];
        int bytesLeft = 0;
        while((bytesLeft = fs.Read(buffer, 0, buffer.Length)) > 0)
        {
            requestStream.Write(buffer, 0, bytesLeft);
        }
    }
    using (var response = (HttpWebResponse)request.GetResponse())
    using (var responseStream = response.GetResponseStream())
    using (var sr = new StreamReader(responseStream))
    {
        var responseString = sr.ReadToEnd();
    }
