    System.Net.WebClient wc = new WebClient();
    string htmlData = UTFConvert(wc.DownloadString(myUri));
    private string UTFConvert(byte[] utfBytes)
    {
        byte[] isoBytes = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, utfBytes);
        return Encoding.Unicode.GetString(isoBytes);
    }
