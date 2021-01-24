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
        var outputFilePath = @"C:\tmp\test.pdf";
        try
        {
            PdfFilePrinter.PrintXpsToPdf(bytes, outputFilePath, "Document Title");
        }
        catch
        {
            // In case of error, delete the potentially corrupted file
            if (File.Exists(outputFilePath))
            {
                File.Delete(outputFilePath);
            }
        }
    }
