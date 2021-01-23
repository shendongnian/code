    private void TestTableCreation() {
        using (FileStream fs = new FileStream("TableTest.pdf", FileMode.Create)) {
            Document doc = new Document(PageSize.A4);
            PdfWriter.GetInstance(doc, fs);
            doc.Open();
            PdfPTable table = new PdfPTable(4);
            for (int i = -100; i < 100; i++) {
                PdfPCell cell = new PdfPCell(new Phrase(String.Format("Alignment: {0}", i)));
                // Give our rows some height so we can see test vertical alignment.
                cell.FixedHeight = 30.0f;
                
                // ** Try it **
                //cell.HorizontalAlignment = Element.ALIGN_LEFT;
                //cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                
                cell.VerticalAlignment = Element.ALIGN_TOP;
                //cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                //cell.VerticalAlignment = Element.ALIGN_BOTTOM;
                
                table.AddCell(cell);
            }
            doc.Add(table);
            doc.Close();
        }
    }
