    public List<int> ReadPdfFile(string fileName, String searthText)
    {
        List<int> pages = new List<int>();
        if (File.Exists(fileName))
        {
            using (PdfReader pdfReader = new PdfReader(fileName))
            using (PdfDocument pdfDocument = new PdfDocument(pdfReader))
            {
                for (int page = 1; page <= pdfDocument.GetNumberOfPages(); page++)
                {
                    ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                    string currentPageText = PdfTextExtractor.GetTextFromPage(pdfDocument.GetPage(page), strategy);
                    if (currentPageText.Contains(searthText))
                    {
                        pages.Add(page);
                    }
                }
            }
        }
        return pages;
    }
