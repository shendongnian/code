    PdfPTable t = new PdfPTable(5);
    //Row 1
    t.AddCell("R1C1");
    t.AddCell("R1C2");
    t.AddCell("R1C3");
    t.AddCell("R1C4");
    t.AddCell("R1C5");
    //Row 2 - One regular cell followed by four spanned cells
    t.AddCell("R2C1");
    t.AddCell(new PdfPCell(new Phrase("R2C2-5")) { Colspan = 4 });
    
    //Row 3 - Four spanned cells followed by one regular cell
    t.AddCell(new PdfPCell(new Phrase("R3C1-4")) { Colspan = 4 });
    t.AddCell("R3C5");
