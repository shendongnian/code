    public static void PrintFile(string xpsSourcePath, string pdfOutputPath)
    {
        // Write XPS file to memory stream
        var ms = new MemoryStream();
        var package = Package.Open(ms, FileMode.Create);
        var doc = new XpsDocument(package);
        var writer = XpsDocument.CreateXpsDocumentWriter(doc);
        writer.Write(xpsSourcePath);
        doc.Close();
        package.Close();
        // Get XPS file bytes
        var bytes = ms.ToArray();
        ms.Dispose();
        // Print to PDF
        PdfPrinter.PrintXpsToPdf(bytes, pdfOutputPath, "Document title");
    }
