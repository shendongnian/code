    var cssText = File.ReadAllText(MapPath("~/Style1.css"));
    var html = File.ReadAllText(MapPath("~/HtmlPage1.html"));
    using (var cssMemoryStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(cssText)))
    {
        using (var htmlMemoryStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(html)))
        {
            doc.NewPage();
            XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, htmlMemoryStream, cssMemoryStream);
        }
    }
    doc.Close();
