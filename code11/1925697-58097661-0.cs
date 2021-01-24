    static  string GetPdfText(string url)
    {
        var separator="\n----------------------------------------------------------------------\n";
        var text = new StringBuilder();                            
        var  strategy = new SimpleTextExtractionStrategy();
        using( var pdfReader = new PdfReader(url))
        {
            for (int page = 1; page <= pdfReader.NumberOfPages; page++)
            {
                var  currentText = PdfTextExtractor.GetTextFromPage(pdfReader, page, strategy);
                text.Append(separator);
                text.Append(currentText);
            }
        }
        return text.ToString();     
    }        
