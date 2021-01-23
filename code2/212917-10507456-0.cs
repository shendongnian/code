    PdfReader reader = new PdfReader("1.pdf");
    Document document = new Document(reader.GetPageSize(1));
    PdfCopy copier = new PdfCopy(doc, new FileStream("2.pdf", FileMode.Create));
    for (int pageCounter = 1; pageCounter < reader.NumberOfPages + 1; pageCounter++)
    {
        // get page
        PdfImportedPage page = copier.GetImportedPage(reader, pageCounter)
        // add content to imported page
        PageStamp ps = pdfCopy.CreatePageStamp(page);
        PdfContentByte cb = ps.GetOverContent();
        // set color
        cb.SetColorFill(BaseColor.BLACK);
        // get font
        BaseFont baseFont = BaseFont.CreateFont(string.Format("{0}\\Fonts\\arialuni.ttf", Environment.GetEnvironmentVariable("windir"), BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
        cb.SetFontAndSize(baseFont, 12);
        cb.BeginText();
        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, printLangString, 100f, 40f, 0f);
        cb.EndText();
        // Accept changes                    
        ps.AlterContents();
        // add page
        copier.AddPage(page);
    }
    using (var ms = new MemoryStream())
    {
        Document doc = new Document(PageSize.A4);
        PdfWriter writer = PdfWriter.GetInstance(doc, ms);
        writer.CloseStream = false;
        doc.Open();
        doc.NewPage();
        doc.Add(new Paragraph(error, fontRed));
        doc.Close();
        writer.Close();
        ms.Seek(0, SeekOrigin.Begin);
        PdfReader rd = new PdfReader(ms);
        for (int pageCounter = 1; pageCounter < reader.NumberOfPages + 1; pageCounter++)
        {
            copier.AddPage(copier.GetImportedPage(rd, pageCounter));
        }
        rd.Close();
    }
    document.Close();
    reader.Close();
