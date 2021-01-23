    Document oNewDocument = new Document(PageSize.A4, 20f, 20f, 30f, 10f);
    PdfWriter.GetInstance(oNewDocument, new FileStream(pdfpath + "/" + sSaleInvoicePdf, FileMode.Create));  
    //Create some text to add to the header
    Chunk text= new Chunk("my text");
    Phrase phHeader = new Phrase();
    phHeader.Add(text);
    //Assign the Phrase to PDF Header
    HeaderFooter header = new HeaderFooter(phHeader, false);
    //Add the header to the document
    oNewDocument.Header = header;
