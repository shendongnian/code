    private ActionResult ConcatPdf(List<byte[]> pdfDataList)
    {
        MemoryStream outputMS = new MemoryStream();
        Document document = new Document();
        PdfCopy writer = new PdfCopy(document, outputMS);
        PdfImportedPage page = null;
                
        document.Open();
    
        foreach (byte[] pdfData in pdfDataList)
        {
            PdfReader reader = new PdfReader(pdfData);
            int n = reader.NumberOfPages;
    
            for (int i = 1; i <= n; i++)
            {
                page = writer.GetImportedPage(reader, i);
                writer.AddPage(page);
            }
    
            PRAcroForm form = reader.AcroForm;
            if (form != null)
                writer.CopyAcroForm(reader);
        }
            
        document.Close();
    
        return File(outputMS.ToArray(), "application/pdf");
    }
