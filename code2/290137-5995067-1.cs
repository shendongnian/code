    public string ConvertRtfToHtml(string rtfString)
    {
        string sourceRtf = "some rtf";
        byte[] data = ASCIIEncoding.Default.GetBytes(sourceRtf);
        using (MemoryStream ms = new MemoryStream(data))
        {
             // call the method above
             return ConvertRtfToHtml(ms);
        }
    }
