    mainDocPart.Document = doc; //you define earlier but do not used.
    doc.Body = new Body();
    SectionProperties sectionProperties1 = 
    mainDocPart.Document.Body.Descendants<SectionProperties>()?.FirstOrDefault();  
    if (sectionProperties1 == null)
    {
        sectionProperties1 = new SectionProperties() { };
        mainDocPart.Document.Body.Append(sectionProperties1);
    }
