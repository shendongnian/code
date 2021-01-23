    var sectionProps = null;
    
    if (doc.MainDocumentPart.Document.Body.Elements<SectionProperties>().Count == 0)
    {
    sectionProps = new SectionProperties();
    doc.MainDocumentPart.Document.Body.Append(sectionProps);
    }
    else
    {
    sectionProps = doc.MainDocumentPart.Document.Body.Elements<SectionProperties>().Last();
    }
