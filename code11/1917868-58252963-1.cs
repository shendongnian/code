     public static class TemplateHTML
        {
            public static string GetTemplate(string pathtoTemplate)
            {
                using (WebClient client = new WebClient())
                {
                    var encodingbody = client.DownloadData(CaminhoTemplate);
                    return Encoding.UTF8.GetString(encodingbody);
                }
            }
        }
    var body = TemplateHTML.GetTemplate("http://example.com/umbraco/surface/Template/Template")
