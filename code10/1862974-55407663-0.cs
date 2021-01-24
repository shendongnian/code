    Body body = mainPart.Document.AppendChild(new Body());
    foreach (var item in paragraphItems)
    {
        Paragraph para = new Paragraph();
        // set the inner Xml of the new paragraph
        para.InnerXml = item.InnerXml;
        if (item.ParagraphProperties != null) // added when testing as was throwing error
        {
            para.Append(item.ParagraphProperties.CloneNode(true));
        }
        // append paragraph to body here
        body.AppendChild(para);
    }
    run.AppendChild(item.InnerXml);
