    public static byte[] ConvertHtmlToOpenXml(string html)
    {
        using (var generatedDocument = new MemoryStream())
        {
            using (var package = WordprocessingDocument.Create(generatedDocument, WordprocessingDocumentType.Document))
            {
                var mainPart = package.MainDocumentPart;
                if (mainPart == null)
                {
                    mainPart = package.AddMainDocumentPart();
                    new Document(new Body()).Save(mainPart);
                }
                var converter = new HtmlConverter(mainPart);
                converter.ParseHtml(html);
                mainPart.Document.Save();
            }
            return generatedDocument.ToArray();
        }
    }
