    RenderFilter[] filters = new RenderFilter[1];
    LocationTextExtractionStrategy regionFilter = new LocationTextExtractionStrategy();
    filters[0] = new RegionTextRenderFilter(new Rectangle(llx,lly,urx,ury));
    FilteredTextRenderListener strategy = new FilteredTextRenderListener(regionFilter, filters);
    String result = PdfTextExtractor.GetTextFromPage(pdfReader, i, strategy);
    Console.WriteLine(result);
