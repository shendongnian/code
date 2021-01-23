    // POST a JSON string
    void POST(string url, string jsonContent) 
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "POST";
        Byte[] byteArray = encoding.GetBytes(jsonContent);
        request.ContentLength = byteArray.Length;
        request.ContentType = @"application/json";
        System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
        using (Stream dataStream = request.GetRequestStream()) {
            dataStream.Write(byteArray, 0, byteArray.Length);
        }
        long length = 0;
        try {
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse()) {
                length = response.ContentLength;
            }
        }
        catch (WebException ex) {
            // Log exception and throw as for GET example above
        }
    }
