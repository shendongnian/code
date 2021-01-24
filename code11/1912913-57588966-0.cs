    `string dest = "destination pdf's path"
    //Initialize PDF Writer
    writer = new PdfWriter(dest);
    //Initialize PDF Document
    pdf = new PdfDocument(writer);
    // Initialize document
    document = new Document(pdf, PageSize.A4);
    //You page text here
    Paragraph p = new Paragraph("bla bla bla bla ");
    document.Add(p);
    //Write what ever you want to write on the page...
    .
    .
    Paragraph footer = new Paragraph("some text")
    footer.SetFixedPosition(72f, 50f, 500f); 
    footer.SetFontSize(6f);
    document.Add(footer);
    document.Close();`    
