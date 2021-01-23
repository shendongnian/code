    void ProxyRequest(HttpListenerResponse httpResponse)
    {
        HttpWebRequest HttpWReq = (HttpWebRequest)WebRequest.Create("http://localhost:2345");
        HttpWebResponse HttpWResp = (HttpWebResponse)HttpWReq.GetResponse();
        // Solution!!!
        httpResponse.SendChunked = true;
      
        byte[] buffer = new byte[32768];
        int bytesWritten = 0;
        while (true)
        {
            int read = HttpWResp.GetResponseStream().Read(buffer, 0, buffer.Length);
            if (read <= 0)
                break;
            httpResponse.OutputStream.Write(buffer, 0, read);
            bytesWritten += read;
        }
    }
