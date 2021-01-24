    // for each page to read...
    for (int i = 1; i <= pagesToRead; ++i)
    {
        var strategy = new iText.Kernel.Pdf.Canvas.Parser.Listener.LocationTextExtractionStrategy();
        // get the page and save it
        var page = pdfDocument.GetPage(i);
        var txt = iText.Kernel.Pdf.Canvas.Parser.PdfTextExtractor.GetTextFromPage(page, strategy);
        pages.Add(txt);
    }
