    /// <summary>This method is called when another split document is to be created.</summary>
    /// <remarks>
    /// This method is called when another split document is to be created.
    /// You can override this method and return your own
    /// <see cref="T:iText.Kernel.Pdf.PdfWriter" />
    /// depending on your needs.
    /// </remarks>
    /// <param name="documentPageRange">the page range of the original document to be included in the document being created now.
    /// </param>
    /// <returns>the PdfWriter instance for the document which is being created.</returns>
    protected internal virtual PdfWriter GetNextPdfWriter(PageRange documentPageRange)
