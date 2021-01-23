    public static void AddContentDispositionHeader(HttpResponse response, string disposition, string fileName)
    {
        if (response == null)
            throw new ArgumentNullException("response");
        StringBuilder sb = new StringBuilder(disposition + "; filename=\"");
        string text;
        if ((HttpContext.Current != null) && (string.Compare(HttpContext.Current.Request.Browser.Browser, "IE", StringComparison.OrdinalIgnoreCase) == 0))
        {
            text = HttpUtility.UrlPathEncode(fileName);
        }
        else
        {
            text = fileName;
        }
        sb.Append(text);
        sb.Append("\"");
        response.AddHeader("Content-Disposition", sb.ToString());
    }
