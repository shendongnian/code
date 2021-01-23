    private void ThreadProcSafe()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader sr = new StreamReader(response.GetResponseStream());
        string res = sr.ReadToEnd();
        sr.Close();
        this.SetText(res);
    }
