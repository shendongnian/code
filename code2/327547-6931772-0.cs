    // Serialize RichTextBox content into a stream in Xaml or XamlPackage format. (Note: XamlPackage format isn't supported in partial trust.)
    TextRange sourceDocument = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
    MemoryStream stream = new MemoryStream();
    sourceDocument.Save(stream, DataFormats.Xaml);
    // Clone the source document's content into a new FlowDocument.
    FlowDocument flowDocumentCopy = new FlowDocument();
    TextRange copyDocumentRange = new TextRange(flowDocumentCopy.ContentStart, flowDocumentCopy.ContentEnd);
    copyDocumentRange.Load(stream, DataFormats.Xaml);
    // Create a XpsDocumentWriter object, open a Windows common print dialog.
    // This methods returns a ref parameter that represents information about the dimensions of the printer media.
    PrintDocumentImageableArea ia = null;
    XpsDocumentWriter docWriter = PrintQueue.CreateXpsDocumentWriter(ref ia);
    if (docWriter != null && ia != null)
    {
        DocumentPaginator paginator = ((IDocumentPaginatorSource)flowDocumentCopy).DocumentPaginator;
        // Change the PageSize and PagePadding for the document to match the CanvasSize for the printer device.
        paginator.PageSize = new Size(ia.MediaSizeWidth, ia.MediaSizeHeight);
        Thickness pagePadding = flowDocumentCopy.PagePadding;
        flowDocumentCopy.PagePadding = new Thickness(
                Math.Max(ia.OriginWidth, pagePadding.Left),
                Math.Max(ia.OriginHeight, pagePadding.Top),
                Math.Max(ia.MediaSizeWidth - (ia.OriginWidth + ia.ExtentWidth), pagePadding.Right),
                Math.Max(ia.MediaSizeHeight - (ia.OriginHeight + ia.ExtentHeight), pagePadding.Bottom));
        flowDocumentCopy.ColumnWidth = double.PositiveInfinity;
        // Send DocumentPaginator to the printer.
        docWriter.Write(paginator);
    }
