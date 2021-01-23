    string[] collection = { "vivek", "kashyap", "viral", "darshit", "arpit", "sameer", "vanraj" };
    PdfDocument pdfDoc = new PdfDocument();
    int records = collection.Length;
    int perpage = 3;
    int pages = (int)Math.Ceiling((double)records / (double)perpage);
    int idx = 0;
    for (int p = 0; p < pages; p++)
    {
        PdfPage pdfPage = new PdfPage();
        pdfPage.Size = PageSize.Letter;
        pdfDoc.Pages.Add(pdfPage);
        XFont NormalFont = new XFont("Helvetica", 10, XFontStyle.Regular);
        using (var pdfGfx = XGraphics.FromPdfPage(pdfPage))
        {
            for (int i = 0,next = 100; i < perpage; i++)
            {
                if ((idx + i) >= records.length) break;
                pdfGfx.DrawString("Name : " + collection[idx  + i].ToString(), NormalFont,
                    XBrushes.Black, 55, next, XStringFormats.Default);
                next += 20;
            }
        }
        idx += perpage;
    }
