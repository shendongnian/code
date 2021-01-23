    PdfPTable table = new PdfPTable(2);
    PdfPCell cell = new PdfPCell(new Phrase("Form M.T.R. 17", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 12, iTextSharp.text.Font.BOLD)));
    cell.Colspan = 2;
    cell.Border = 0;
    cell.HorizontalAlignment = Element.ALIGN_LEFT; 
    table.AddCell(cell);
    table.AddCell(new Phrase("PAY-BILL OF GAZETTED OFFICER"));
    
    PdfPCell rCell = new PdfPCell(new Phrase("DDO Code: 703", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 12)));
    rCell.Border = 0;
    rCell.HorizontalAlignment = Element.ALIGN_RIGHT; 
    table.AddCell(rCell);
    pdfDocument.Add(table);
