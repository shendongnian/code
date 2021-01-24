    using (FileStream output = new FileStream(@"TemplateWithTable.pdf", FileMode.Create, FileAccess.Write))
    using (Document document = new Document(PageSize.A4))
    {
        PdfWriter writer = PdfWriter.GetInstance(document, output);
        document.Open();
        PdfPTable table = new PdfPTable(2);
        table.AddCell("Test");
        table.AddCell("Table");
        PdfContentByte canvas = writer.DirectContent;
        PdfTemplate template = canvas.CreateTemplate(300, 800);
        Rectangle pageSize = document.PageSize;
        canvas.AddTemplate(template, pageSize.GetLeft(40), pageSize.GetBottom(200));
        ColumnText ct = new ColumnText(template);
        ct.SetSimpleColumn(new Rectangle(100, 100, 300, 600));
        ct.AddElement(table);
        ct.Go();
        document.Close();
    }
