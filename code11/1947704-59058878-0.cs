    protected FlowDocument RenderBody()
    {
      var flow = new FlowDocument
      {
        PageWidth = PaperSizeDPI.Width,
        PageHeight = PaperSizeDPI.Height,
        ColumnGap = 0,
        ColumnWidth = PaperSizeDPI.Width,
        PagePadding = new Thickness(MarginDPI.Left, MarginDPI.Top + HeaderHeightDPI, MarginDPI.Right, MarginDPI.Bottom + FooterHeightDPI)
      };
      if (m_Blocks == null || m_Blocks.Count <= 0)
        return flow;
      // Get page count before deciding to deal with repeat blocks.
      // Adding blocks to the FlowDocument is required before invoking
      // `DocumentPaginator.ComputePageCount()`.
      flow.Blocks.AddRange(m_Blocks.ToList());
      int GetPageCount()
      {
        var paginatorSource = (IDocumentPaginatorSource) flow;
        paginatorSource.DocumentPaginator.ComputePageCount();
        return paginatorSource.DocumentPaginator.PageCount;
      }
      // If there is only one page, no roll-over of headers necessary
      if (GetPageCount() <= 1) return flow;
      // If we don't have a header to repeat, we assume the report is correct already
      if (PrintTemplateConverter.BuildRepeatableHeader == null) return flow;
      // Build the FlowDocument, one block at a time, checking if the page count
      // changes so that we can inject a repeatable header
      flow.Blocks.Clear();
      var pageCount = 1;
      var blocks = m_Blocks.ToList();
      for (var blockIndex = 0; blockIndex < blocks.Count; blockIndex++)
      {
        flow.Blocks.Add(blocks[blockIndex]);
        if (GetPageCount() <= pageCount) continue;
        // If this block moved us to a new page, inject repeatable header in its spot.
        // `flow.Blocks.AddRange(...)` ignores duplicate blocks (by reference).
        // This is why I go through the "pain" of making a whole new Header block
        // instance.
        var blocksSoFar = flow.Blocks.ToList();
        flow.Blocks.Clear();
        blocksSoFar.Insert(blockIndex, PrintTemplateConverter.BuildRepeatableHeader());
        flow.Blocks.AddRange(blocksSoFar);
        pageCount = GetPageCount();
      }
      return flow;
    }
