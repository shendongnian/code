    public static void FixedDocument2Pdf(FixedDocument fd)
    {
        // Convert FixedDocument to XPS file in memory
        var ms = new MemoryStream();
        var package = Package.Open(ms, FileMode.Create);
        var doc = new XpsDocument(package);
        var writer = XpsDocument.CreateXpsDocumentWriter(doc);
        writer.Write(fd.DocumentPaginator);
        doc.Close();
        package.Close();
        // Get XPS file bytes
        var bytes = ms.ToArray();
        ms.Dispose();
        // Print to PDF
        PdfPrinter.PrintToPdf(bytes, @"C:\tmp\test.pdf", "Document Title");
    }
