    protected internal void ReadPages() {
      catalog = trailer.GetAsDict(PdfName.ROOT);
      rootPages = catalog.GetAsDict(PdfName.PAGES);
      pageRefs = new PageRefs(this);
    }
