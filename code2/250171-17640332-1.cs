    private static void MergeMultiplePDFIntoSinglePDF(string outputFilePath, string[] pdfFiles)
    {
        Console.WriteLine("Merging started.....");
        PdfDocument outputPDFDocument = new PdfDocument(); 
        foreach (string pdfFile in pdfFiles)
        {
            PdfDocument inputPDFDocument = PdfReader.Open(pdfFile, PdfDocumentOpenMode.Import);
            outputPDFDocument.Version = inputPDFDocument.Version; 
            foreach (PdfPage page in inputPDFDocument.Pages)
            {
                outputPDFDocument.AddPage(page);
            }
        }
        outputPDFDocument.Save(outputFilePath); 
        Console.WriteLine("Merging Completed");
    }
