    // ...
    PdfPTable table = new PdfPTable(5);
    PdfPCell[] cells = new PdfPCell[] { new PdfPCell(GetCell("c1")),
                                        new PdfPCell(GetCell("c2")),
                                        new PdfPCell(GetCell("c3")),
                                        new PdfPCell(GetCell("c4")),
                                        new PdfPCell(GetCell("c5"))};
    PdfPRow row = new PdfPRow(cells);
    table.Rows.Add(row);
    // ...
