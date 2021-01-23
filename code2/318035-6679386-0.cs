            //Fixed height of last cell
            float LAST_CELL_HEIGHT = 50f;
            //Create our document with zero margins
            Document document = new Document(PageSize.A4, 0, 0, 0, 0);
            FileStream fs = new FileStream(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "A4.pdf"), FileMode.Create, FileAccess.Write, FileShare.Read);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();
            PdfPCell cell;
            PdfPTable table = new PdfPTable(2);
            table.SetWidths(new float[] { 450, 100 });
            table.WidthPercentage = 100;
            cell = new PdfPCell(new Phrase("Item cod werwerwer"));
            //Set the first cell's height to the document's full height minus the last cell
            cell.MinimumHeight = document.PageSize.Height - LAST_CELL_HEIGHT;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("100"));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(string.Empty));
            //Set the last cell's height
            cell.MinimumHeight = LAST_CELL_HEIGHT;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("100"));
            table.AddCell(cell);
            
            document.Add(table);
            writer.CloseStream = false;
            document.Close();
            fs.Close();
