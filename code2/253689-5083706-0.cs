    public static byte[] InsertTable(byte[] pdf, DataTable dt, int pageNum, float x, float y, int columns, int rows, float[] columnWidths, float rowHeight)
    {
        using (var inputPDF = new MemoryStream(pdf))
        using (var outputPDF = new MemoryStream())
        {
            //loading existing
            var reader = new PdfReader(inputPDF);
            Document doc = new Document();
            PdfWriter write = PdfWriter.GetInstance(doc, outputPDF);
            doc.Open();
            PdfContentByte canvas = write.DirectContent;
            PdfImportedPage page;
            for (int i = 1; i <= reader.NumberOfPages; i++) {
                page = write.GetImportedPage(reader, i);
                canvas.AddTemplate(page, 1f, 0, 0, 1, 0, 0);
            }
            //adding my table
            PdfPTable t = new PdfPTable(columns);
            t.SetTotalWidth(columnWidths);
            foreach (DataRow dr in dt.Rows)
                foreach (object o in dr.ItemArray)
                {
                    PdfPCell c = new PdfPCell();
                    c.AddElement(new Chunk(o.ToString()));
                    t.AddCell(c);
                }
            doc.Add(t);
            doc.Close();
            return outputPDF.ToArray();
        }
    }
