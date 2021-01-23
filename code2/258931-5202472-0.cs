    static string GetContent()
    {
    url = 'http://local.ch';
    WebClient client = new WebClient();
    client.Headers.Add("user-agent", 
    "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
    Stream data = client.OpenRead(url);
    StreamReader reader = new StreamReader(data);
    string s = reader.ReadToEnd();
    data.Close();
    reader.Close();
    return s;
    }
