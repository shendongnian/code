    var document = new HtmlDocument();
    
    using (var client = new WebClient())
    {
        using (var stream = client.OpenRead(url))
        {
            var reader = new StreamReader(stream, Encoding.GetEncoding("iso-8859-9"));
            var html = reader.ReadToEnd();
            document.LoadHtml(html);
        }
    }
