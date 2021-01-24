    PdfReader reader = new PdfReader(srcFilePath);
    PdfWriter writer = new PdfWriter(targetFilePath);
    PdfDocument pdfDoc = new PdfDocument(reader, writer);
    // Remove outlines before getting PdfOutline object by calling GetOutlines
    pdfDocument.GetCatalog().GetPdfObject().Remove(PdfName.Outlines);
    PdfOutline rootOutline = pdfDoc.GetOutlines(false);
