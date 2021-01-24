    public void CreateFile(string resultFile, List<Paragraph> paragraphItems)
    {
        using (WordprocessingDocument wordDocument =
               WordprocessingDocument.Create(resultFile, WordprocessingDocumentType.Document))
        {
            MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
            mainPart.Document = new Document();
            Body body = mainPart.Document.AppendChild(new Body());
            foreach (var item in paragraphItems)
            {
                Paragraph para = new Paragraph();
                // set the inner Xml of the new paragraph
                para.InnerXml = item.InnerXml;
                // append paragraph to body here
                body.AppendChild(para);
            }
        }
    }
