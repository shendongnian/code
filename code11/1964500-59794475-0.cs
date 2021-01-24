    PdfDocument pdfDoc = new PdfDocument(new PdfReader("input.pdf"), new PdfWriter("output.pdf"));
    Document doc = new Document(pdfDoc);
            
    Paragraph footer = new Paragraph("This is a footer").SetFontColor(ColorConstants.RED);
            
    for (int i = 1; i <= pdfDoc.GetNumberOfPages(); i++) 
    {
        Rectangle pageSize = pdfDoc.GetPage(i).GetPageSize();
        float x = pageSize.GetWidth() / 2;
        float y = pageSize.GetBottom() + 20;
        doc.ShowTextAligned(footer, x, y, i, TextAlignment.CENTER, VerticalAlignment.BOTTOM, 0);
    }
            
    doc.Close();
