        List<string> linestringlist = new List<string>();
        PdfReader reader = new PdfReader(pdfFilename);
        iTextSharp.text.Rectangle rect = new iTextSharp.text.Rectangle(coordinate1, coordinate2, coordinate3, coordinate4);
        RenderFilter[] renderFilter = new RenderFilter[1];
        renderFilter[0] = new RegionTextRenderFilter(rect);
        ITextExtractionStrategy textExtractionStrategy = new FilteredTextRenderListener(new LocationTextExtractionStrategy(), renderFilter);
        string text = PdfTextExtractor.GetTextFromPage(reader, 1, textExtractionStrategy);
