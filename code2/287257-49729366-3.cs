    public string ConvertHTMLToRTF(string html)
    {
        SautinSoft.HtmlToRtf h = new SautinSoft.HtmlToRtf();
        return h.ConvertString(htmlString);
    }
    public string ConvertRTFToHTML(string rtf)
    {
        SautinSoft.RtfToHtml r = new SautinSoft.RtfToHtml();
        byte[] bytes = Encoding.ASCII.GetBytes(rtf);
        r.OpenDocx(bytes );
        return r.ToHtml();
    }
