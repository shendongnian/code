    using (MemoryStream ms = new MemoryStream())
    using (PdfDocument pdf = new PdfDocument(new PdfWriter(ms).SetSmartMode(true)))
    {
        // Create reader from bytes
        using (MemoryStream memoryStream = new MemoryStream(pdf1.DocumentBytes))
        {
            // Create reader from bytes
            using (PdfReader reader = new PdfReader(memoryStream))
            {
                PdfDocument srcDoc = new PdfDocument(reader);
                srcDoc.CopyPagesTo(1, srcDoc.GetNumberOfPages(), pdf);
            }
        }
        // Create reader from bytes
        using (MemoryStream memoryStream = new MemoryStream(pdf2.DocumentBytes))
        {
            // Create reader from bytes
            using (PdfReader reader = new PdfReader(memoryStream))
            {
                PdfDocument srcDoc = new PdfDocument(reader);
                srcDoc.CopyPagesTo(1, srcDoc.GetNumberOfPages(), pdf);
            }
        }
        // Close pdf
        pdf.Close();
        // Return array
        return ms.ToArray();
    }
