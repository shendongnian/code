c-sharp
public static HtmlNode GetHtmlNode(string url, string requestLanguageCode)
{
    try
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "GET";
        request.UserAgent = "Mozilla";
        request.Accept = "Accept: text/html";
        request.Headers.Add("Accept-Language: " + requestLanguageCode);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        var stream = response.GetResponseStream();
        using (var reader = new StreamReader(stream))
        {
            string html = reader.ReadToEnd();
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            return doc.DocumentNode;
        }
    }
    catch (WebException)
    {
        return null;
    }
}
