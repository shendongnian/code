    public static string TextToHtml(string text)
    {
        text = "<pre>" + HttpUtility.HtmlEncode(text) + "</pre>";
        return text;
    }
