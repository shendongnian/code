    public static object ExtractPDFDoc(string filename)
    {
        iText.Kernel.Pdf.PdfReader pdfReader = null;
        iText.Kernel.Pdf.PdfDocument pdfDocument = null;
        try
        {
            pdfReader = new iText.Kernel.Pdf.PdfReader(filename);
            pdfDocument = new iText.Kernel.Pdf.PdfDocument(pdfReader);
        }
        catch (Exception ex)
        {
            throw new Exception(string.Format("ExtractPDFDoc() failed on file '{0}' with message '{1}'", filename, ex.Message), ex);
        }
        finally
        {
            pdfReader?.Dispose();
            pdfDocument?.Dispose();
        }
    }
