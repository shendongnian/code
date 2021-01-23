    try
    {strBody = "<html>" + "<body>" + "<div> Word File </div>" + "</body>" + "</html>";
    using (MemoryStream generatedDocument = new MemoryStream())
    {
    using (WordprocessingDocument package = WordprocessingDocument.Create(generatedDocument, WordprocessingDocumentType.Document))
    {
    MainDocumentPart mainPart = package.MainDocumentPart;
    if (mainPart == null)
    {
    mainPart = package.AddMainDocumentPart();
    new Document(new Body()).Save(mainPart);
    }
    
    HtmlConverter converter = new HtmlConverter(mainPart);
    converter.ExcludeLinkAnchor = true;
    converter.RefreshStyles();
    converter.ImageProcessing = ImageProcessing.AutomaticDownload;
    converter.BaseImageUrl = new Uri(domainNameURL + "Images/");
    
    Body body = mainPart.Document.Body;
    converter.ConsiderDivAsParagraph = false;
    
    var paragraphs = converter.Parse({strBody);
    for (int i = 0; i < paragraphs.Count; i++)
    {
    body.Append(paragraphs[i]);
    }
    
    mainPart.Document.Save();
    }
    
    File.WriteAllBytes(filename, generatedDocument.ToArray());
    }
    
    using (WordprocessingDocument myDoc = WordprocessingDocument.Open(filename, true))
    {
    XNamespace w =
    "http://schemas.openxmlformats.org/wordprocessingml/2006/main";
    XNamespace r =
    "http://schemas.openxmlformats.org/officeDocument/2006/relationships";
    string altChunkId = "AltChunkId1";
    MainDocumentPart mainPart = myDoc.MainDocumentPart;
    AlternativeFormatImportPart chunk = mainPart.AddAlternativeFormatImportPart("application/xhtml+xml", altChunkId);
    
    using (Stream chunkStream = chunk.GetStream(FileMode.Create, FileAccess.Write))
    using (StreamWriter stringStream = new StreamWriter(chunkStream))
    stringStream.Write(html);
    XElement altChunk = new XElement(w + "altChunk",
    new XAttribute(r + "id", altChunkId)
    );
    XDocument mainDocumentXDoc = GetXDocument(myDoc);
    mainDocumentXDoc.Root
    .Element(w + "body")
    .Elements(w + "p")
    .Last()
    .AddAfterSelf(altChunk);
    SaveXDocument(myDoc, mainDocumentXDoc);
    }
    System.Diagnostics.Process.Start(filename);
    }
    catch (Exception ex)
    {
    Response.Write(ex.ToString());
    }
