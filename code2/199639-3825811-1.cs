    private static void DemoTableSpacing() {
        using (FileStream fs = new FileStream("SpacingTest.pdf", FileMode.Create)) {
    
            Document doc = new Document();
            PdfWriter.GetInstance(doc, fs);
            doc.Open();
    
            Paragraph paragraphTable1 = new Paragraph();
            paragraphTable1.SpacingAfter = 15f;
    
            PdfPTable table = new PdfPTable(3);
            PdfPCell cell = new PdfPCell(new Phrase("This is table 1"));
            cell.Colspan = 3;
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);
            table.AddCell("Col 1 Row 1");
            table.AddCell("Col 2 Row 1");
            table.AddCell("Col 3 Row 1");
            //table.AddCell("Col 1 Row 2");
            //table.AddCell("Col 2 Row 2");
            //table.AddCell("Col 3 Row 2");
            paragraphTable1.Add(table);
            doc.Add(paragraphTable1);
    
            Paragraph paragraphTable2 = new Paragraph();
            paragraphTable2.SpacingAfter = 10f;
    
            table = new PdfPTable(3);
            cell = new PdfPCell(new Phrase("This is table 2"));
            cell.Colspan = 3;
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);
            table.AddCell("Col 1 Row 1");
            table.AddCell("Col 2 Row 1");
            table.AddCell("Col 3 Row 1");
            table.AddCell("Col 1 Row 2");
            table.AddCell("Col 2 Row 2");
            table.AddCell("Col 3 Row 2");
            paragraphTable2.Add(table);
            doc.Add(paragraphTable2);
            doc.Close();
        }
    }
        
