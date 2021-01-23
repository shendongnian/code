    static public byte[] GetBytesFromUrl(string url)
    {
        byte[] b;
        HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(url);
        WebResponse myResp = myReq.GetResponse();
        Stream stream = myResp.GetResponseStream();
        using (BinaryReader br = new BinaryReader(stream))
        {
            b = br.ReadBytes(100000000);
            br.Close();
        }
        myResp.Close();
        return b;
    }
