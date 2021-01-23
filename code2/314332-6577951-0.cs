    using (Stream fileStream = new FileStream(imgPath, FileMode.Open, FileAccess.Read))
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "POST";
        request.ContentType = "image/png";
        request.ContentLength = fileStream.Length;
        request.Headers.Add(HttpRequestHeader.Authorization, "GoogleLogin auth=" + auth);
        request.Headers.Add("Slug", "test");
        using (Stream requestStream = request.GetRequestStream())
        {
            byte[] buffer = new byte[4096];
            int bytesRead = 0;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                requestStream.Write(buffer, 0, bytesRead);
            }
            fileStream.Close();
            requestStream.Close();
        }
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader responseReader = new StreamReader(response.GetResponseStream());
        string responseStr = responseReader.ReadToEnd();
    }
