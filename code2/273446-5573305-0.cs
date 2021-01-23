    var doc = new Document();
    using (var stream = File.Create("output.pdf"))
    {
        var writer = PdfWriter.GetInstance(doc, stream);
        doc.Open();
        doc.Add(Image.GetInstance(@"c:\foo\test.png"));
        var cb = writer.DirectContent;
        cb.BeginText();
        cb.SetTextMatrix(100, 220);
        var font = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
        cb.SetFontAndSize(font, 12);
        cb.ShowText("Hello World");
        cb.EndText();
        cb.BeginText();
        cb.SetTextMatrix(100, 250);
        cb.ShowText("Some other text");
        cb.EndText();
        doc.Close();
    }
