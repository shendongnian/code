    using (WebResponse response = request.GetResponse())
    {
        using (Stream stream = response.GetResponseStream())
        {
            byte[] bytes = new byte[bytesToGet];
            int count = stream.Read(bytes, 0, bytesToGet);
            Encoding encoding = Encoding.GetEncoding(response.Encoding);
            result = encoding.GetString(bytes, 0, count);
        }
    }
